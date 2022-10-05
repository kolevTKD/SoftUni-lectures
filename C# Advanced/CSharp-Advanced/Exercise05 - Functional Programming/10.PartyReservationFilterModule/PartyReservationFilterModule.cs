using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationFilterModule
{
    internal class PartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            Action<List<string>> print = p => Console.WriteLine(string.Join(' ', p));

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            while (input != "Print")
            {
                string[] cmdArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string filter = cmdArgs[1];
                string parameter = cmdArgs[2];

                if (action == "Add filter")
                {
                    filters.Add(filter + parameter, FilterModule(filter, parameter));
                }

                else if (action == "Remove filter")
                {
                    filters.Remove(filter + parameter);
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }

            print(people);
        }

        static Predicate<string> FilterModule(string filter, string parameter)
        {
            switch (filter)
            {
                case "Starts with":
                    return s => s.StartsWith(parameter);
                case "Ends with":
                    return s => s.EndsWith(parameter);
                case "Length":
                    return s => s.Length == int.Parse(parameter);
                case "Contains":
                    return s => s.Contains(parameter);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}
