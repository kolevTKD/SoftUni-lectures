using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    class TreasureHunt
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine().Split('|').ToList();
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = commands[0];
            string end = "Yohoho!";
            double sum = 0;

            while (command != end)
            {
                if (command == "Loot")
                {
                    Loot(loot, commands);
                }

                else if (command == "Drop")
                {
                    int index = int.Parse(commands[1]);
                    Drop(loot, index);
                }

                else if (command == "Steal")
                {
                    int count = int.Parse(commands[1]);
                    Steal(loot, count);
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = commands[0];
            }

            for (int index = 0; index < loot.Count; index++)
            {
                string currentWord = loot[index];
                sum += currentWord.Length;
            }

            double averagePirateCredits = sum / loot.Count;

            if (loot.Count != 0)
            {
                Console.WriteLine($"Average treasure gain: {averagePirateCredits:f2} pirate credits.");
                return;
            }

            Console.WriteLine("Failed treasure hunt.");
        }

        static List<string> Loot(List<string> loot, string[] lootings)
        {
            int indexToInsert = 0;
            for (int index = lootings.Length - 1; index >= 1; index--)
            {
                string currentLoot = lootings[index];

                if (!loot.Contains(currentLoot))
                {
                    loot.Insert(indexToInsert, currentLoot);
                    indexToInsert++;
                }
            }

            return loot;
        }

        static List<string> Drop(List<string> loot, int index)
        {
            if (index >= 0 && index < loot.Count)
            {
                string item = loot[index];
                loot.RemoveAt(index);
                loot.Add(item);
            }

            return loot;
        }

        static List<string> Steal(List<string> loot, int count)
        {
            if (count > loot.Count)
            {
                count = loot.Count;
            }
            List<string> removedLoot = new List<string>();

            for (int index = 1; index <= count; index++)
            {
                removedLoot.Insert(0, loot[loot.Count - 1]);
                loot.RemoveAt(loot.Count - 1);
            }

            Console.WriteLine(string.Join(", ", removedLoot));

            return loot;
        }
    }
}
