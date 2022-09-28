using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    internal class FilterByAge
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Person[] people = new Person[count];
            Func<Person, string, int, bool> filter = (p, c, a) => c == "older" ? p.Age >= a : p.Age < a;
            Func<Person, string[], string> formatter = (p, f) =>
            {
                string formattedString = string.Empty;

                if (f.Length == 2)
                {
                    if (f[0] == "name")
                    {
                        formattedString = "{0} - {1}";
                    }

                    else
                    {
                        formattedString = "{1} - {0}";
                    }
                }

                else
                {
                    if (f[0] == "name")
                    {
                        formattedString = "{0}";
                    }

                    else
                    {
                        formattedString = "{1}";
                    }
                }

                return string.Format(formattedString, p.Name, p.Age);
            };

            for (int i = 0; i < count; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person()
                {
                    Name = personInfo[0],
                    Age = int.Parse(personInfo[1])
                };
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(Environment.NewLine, people
                .Where(p => filter(p, condition, age))
                .Select(p => formatter(p, format))));

        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
