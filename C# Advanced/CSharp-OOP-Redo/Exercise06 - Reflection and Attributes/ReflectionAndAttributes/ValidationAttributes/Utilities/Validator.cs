namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            //Returns all properties that have attributes which's parent is MyValidationAttribute
            //The parent can be derrived from the child 
            PropertyInfo[] properties = type.GetProperties()
                .Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                //Returns instances of all custom attributes attached to the property. No need to declare constructor parameters.
                object[] customAttributes = property.GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                    .ToArray();

                object propValue = property.GetValue(obj);

                foreach (object customAttribute in customAttributes)
                {
                    Type attributeType = customAttribute.GetType();

                    MethodInfo isValidMethod = attributeType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .FirstOrDefault(m => m.Name == "IsValid");

                    if (isValidMethod == null)
                    {
                        throw new InvalidOperationException("There is no IsValid method!");
                    }

                    bool result = (bool)isValidMethod.Invoke(customAttribute, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
