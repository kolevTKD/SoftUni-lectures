using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ManOWar
{
    class ManOWar
    {
        static void Main(string[] args)
        {
            List<int> pirateshipStatus = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            List<int> warshipStatus = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = commands[0];
            string end = "Retire";

            while (command != end)
            {
                if (command == "Fire")
                {
                    int index = int.Parse(commands[1]);
                    int damage = int.Parse(commands[2]);

                    if (index >= 0 && index < warshipStatus.Count)
                    {
                        warshipStatus[index] -= damage;

                        if (warshipStatus[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }

                else if (command == "Defend")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int damage = int.Parse(commands[3]);

                    if (startIndex >= 0 && startIndex < pirateshipStatus.Count
                    && endIndex >= 0 && endIndex < pirateshipStatus.Count)
                    {
                        for (int index = startIndex; index <= endIndex; index++)
                        {
                            pirateshipStatus[index] -= damage;

                            if (pirateshipStatus[index] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }

                else if (command == "Repair")
                {
                    int index = int.Parse(commands[1]);
                    int health = int.Parse(commands[2]);

                    if (index >= 0 && index < pirateshipStatus.Count)
                    {
                        pirateshipStatus[index] += health;

                        if (pirateshipStatus[index] + health > maxHealth)
                        {
                            pirateshipStatus[index] = maxHealth;
                        }
                    }
                }

                else if (command == "Status")
                {
                    double lowHP = maxHealth * 0.2;
                    int sectionsForRepair = 0;

                    for (int index = 0; index < pirateshipStatus.Count; index++)
                    {
                        if (pirateshipStatus[index] < lowHP)
                        {
                            sectionsForRepair++;
                        }
                    }

                    Console.WriteLine($"{sectionsForRepair} sections need repair.");
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = commands[0];
            }

            int pirateshipSum = pirateshipStatus.Sum();
            int warshipSum = warshipStatus.Sum();
            Console.WriteLine($"Pirate ship status: {pirateshipSum}");
            Console.WriteLine($"Warship status: {warshipSum}");
        }
    }
}
