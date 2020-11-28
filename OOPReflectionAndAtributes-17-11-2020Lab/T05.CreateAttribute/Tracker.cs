namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type typeOfClass = typeof(StartUp);
            MethodInfo[] methods = typeOfClass.GetMethods(BindingFlags.Public 
                | BindingFlags.Instance | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes();
                    foreach (AuthorAttribute attr in attributes)
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
