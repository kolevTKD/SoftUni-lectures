using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ForceBook
{
    internal class ForceBook
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> sides = new SortedDictionary<string, SortedSet<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Lumpawaroo")
                {
                    break;
                }

                if (command.Contains('|'))
                {
                    string[] cmdArgs = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = cmdArgs[0];
                    string forceUser = cmdArgs[1];

                    if (!sides.Values.Any(x => x.Contains(forceUser)))
                    {
                        if (!sides.ContainsKey(forceSide))
                        {
                            sides.Add(forceSide, new SortedSet<string>());
                        }

                        sides[forceSide].Add(forceUser);
                    }
                }

                else if (command.Contains("->"))
                {
                    string[] cmdArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = cmdArgs[0];
                    string forceSide = cmdArgs[1];

                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            side.Value.Remove(forceUser);
                            break;
                        }
                    }

                    if (!sides.ContainsKey(forceSide))
                    {
                        sides.Add(forceSide, new SortedSet<string>());
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    sides[forceSide].Add(forceUser);
                }
            }

            var sortedSides = sides.OrderByDescending(x => x.Value.Count);

            foreach (var side in sortedSides)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                }

                foreach (var user in side.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
