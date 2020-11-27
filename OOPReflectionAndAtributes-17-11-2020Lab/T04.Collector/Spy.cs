namespace Stealer
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToGet)
        {
            Type typeOfClass = Type.GetType(classToInvestigate);
            FieldInfo[] gotFields = typeOfClass.GetFields(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);
            Object hackerObject = Activator.CreateInstance(typeOfClass, new object[] { });
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {typeOfClass.FullName}");
            foreach (var item in gotFields.Where(x => fieldsToGet.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(hackerObject)}");
            }
            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type typeOfClass = Type.GetType(className);
            FieldInfo[] publicFields = typeOfClass.GetFields(BindingFlags.Public
                | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] methodsInfo = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in publicFields)
                sb.AppendLine($"{field.Name} must be private!");

            foreach (MethodInfo method in methodsInfo)
            {
                if (method.Name.StartsWith("get") && method.IsPrivate)
                    sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in methodsInfo)
            {
                if (method.Name.StartsWith("set") && method.IsPublic)
                    sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type typeOfClass = Type.GetType(className);
            MethodInfo[] allPrivateMethods = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {typeOfClass.FullName}");
            sb.AppendLine($"Base Class: {typeOfClass.BaseType.Name}");

            foreach (MethodInfo method in allPrivateMethods)
                sb.AppendLine(method.Name);

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type typeOfClass = Type.GetType(className);
            MethodInfo[] allMethods = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance 
                | BindingFlags.Public | BindingFlags.Static);
            
            MethodInfo[] allGetters = allMethods.Where(x => x.Name.StartsWith("get")).ToArray();
            MethodInfo[] allSetters = allMethods.Where(x => x.Name.StartsWith("set")).ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var getter in allGetters)
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType.FullName}");
            foreach (var setter in allSetters)
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");

            return sb.ToString().Trim();
        }
    }
}
