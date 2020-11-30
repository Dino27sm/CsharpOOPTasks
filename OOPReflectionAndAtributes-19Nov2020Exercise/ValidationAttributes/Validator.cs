namespace ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] objProperties = obj.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in objProperties)
            {
                IEnumerable<MyValidationAttribute> propertyAttr = propertyInfo.GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attr in propertyAttr)
                {
                    bool isValid = attr.IsValid(propertyInfo.GetValue(obj));
                    if (!isValid)
                        return false;
                }
            }
            return true;
        }
    }
}
