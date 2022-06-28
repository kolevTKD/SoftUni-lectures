using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Inventory
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = commands[0];
            string end = "Craft!";

            while (command != end)
            {
                string item = commands[1];

                switch (command)
                {
                    case "Collect":

                        Collect(inventory, item);
                        break;

                    case "Drop":

                        Drop(inventory, item);
                        break;

                    case "Combine Items":
                        string[] items = commands[1].Split(':').ToArray();
                        string item1 = items[0];
                        string item2 = items[1];

                        CombineItems(inventory, item1, item2);
                        break;

                    case "Renew":
                        Renew(inventory, item);
                        break;
                }
                commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = commands[0];
            }

            Console.WriteLine(string.Join(", ", inventory));
        }

        static List<string> Collect(List<string> inventory, string item)
        {
            if (!inventory.Contains(item))
            {
                inventory.Add(item);
            }

            return inventory;
        }

        static List<string> Drop(List<string> inventory, string item)
        {
            inventory.Remove(item);

            return inventory;
        }

        static List<string> CombineItems(List<string> inventory, string oldItem, string newItem)
        {
            if (inventory.Contains(oldItem))
            {
                int oldItemIndex = 0;

                for (int index = 0; index < inventory.Count; index++)
                {
                    if (inventory[index] == oldItem)
                    {
                        oldItemIndex = index;
                        break;
                    }
                }

                inventory.Insert(oldItemIndex + 1, newItem);
            }

            return inventory;
        }

        static List<string> Renew(List<string> inventory, string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
                inventory.Add(item);
            }

            return inventory;
        }
    }
}
