namespace AuthorProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    IEnumerable<Attribute> attributes = method.GetCustomAttributes();

                    foreach (AuthorAttribute currAttribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {currAttribute.Name}");
                    }
                }
            }
        }
    }
}
