using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class ShoppingList
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = commands[0];
            string end = "Go";

            while (command != end)
            {
                string grocery = commands[1];

                switch (command)
                {
                    case "Urgent":
                        if (!groceries.Contains(grocery))
                        {
                            AddToStart(groceries, grocery);
                        }
                        break;
                    case "Unnecessary":
                        if (groceries.Contains(grocery))
                        {
                            Remove(groceries, grocery);
                        }
                        break;
                    case "Correct":
                        string newGrocery = commands[2];

                        if (groceries.Contains(grocery))
                        {
                            Replace(groceries, grocery, newGrocery);
                        }
                        break;
                    case "Rearrange":
                        if (groceries.Contains(grocery))
                        {
                            Rearrange(groceries, grocery);
                        }
                        break;

                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = commands[0];
            }
            Console.WriteLine(string.Join(", ", groceries));
        }

        static List<string> AddToStart(List<string> groceries, string grocery)
        {
            groceries.Insert(0, grocery);
            return groceries;
        }

        static List<string> Remove(List<string> groceries, string grocery)
        {
            groceries.Remove(grocery);
            return groceries;
        }

        static List<string> Replace(List<string> groceries, string oldGrocery, string newGrocery)
        {
            for (int index = 0; index < groceries.Count; index++)
            {
                if (groceries[index] == oldGrocery)
                {
                    groceries[index] = newGrocery;
                    break;
                }
            }

            return groceries;
        }

        static List<string> Rearrange(List<string> groceries, string grocery)
        {
            for (int index = 0; index < groceries.Count; index++)
            {
                if (groceries[index] == grocery)
                {
                    groceries.RemoveAt(index);
                    groceries.Add(grocery);
                    break;
                }
            }
            return groceries;
        }
    }
}
