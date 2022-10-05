using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty
{
    internal class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string cmd = cmdArgs[1];
                string parameter = cmdArgs[2];

                if (action == "Double")
                {
                    List<string> peopleToDouble = names.FindAll(GetPredicate(cmd, parameter));

                    foreach (string name in peopleToDouble)
                    {
                        int index = names.IndexOf(name);
                        names.Insert(index, name);
                    }
                }

                else if (action == "Remove")
                {
                    names.RemoveAll(GetPredicate(cmd, parameter));
                }

                input = Console.ReadLine();
            }

            if (names.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");

                return;
            }

            Console.WriteLine("Nobody is going to the party!");
        }

        static Predicate<string> GetPredicate(string command, string parameter)
        {
            switch (command)
            {
                case "StartsWith":
                    return s => s.StartsWith(parameter);
                case "EndsWith":
                    return s => s.EndsWith(parameter);
                case "Length":
                    return s => s.Length == int.Parse(parameter);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}
