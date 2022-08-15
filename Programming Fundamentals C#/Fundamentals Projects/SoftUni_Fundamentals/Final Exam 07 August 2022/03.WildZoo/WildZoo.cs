using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WildZoo
{
    class WildZoo
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> animalsInfo = new Dictionary<string, Dictionary<string, int>>();


            while (true)
            {
                string[] commands = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "EndDay")
                {
                    break;
                }

                string[] animalReq = commands[1].Split("-", StringSplitOptions.RemoveEmptyEntries);
                string animalName = animalReq[0];
                int foodQuantity = int.Parse(animalReq[1]);

                if (command == "Add")
                {
                    string area = animalReq[2];

                    if (!animalsInfo.ContainsKey(area))
                    {
                        animalsInfo.Add(area, new Dictionary<string, int>());
                        animalsInfo[area].Add(animalName, foodQuantity);
                    }

                    else
                    {
                        if (!animalsInfo[area].ContainsKey(animalName))
                        {
                            animalsInfo[area].Add(animalName, foodQuantity);
                        }

                        else
                        {
                            animalsInfo[area][animalName] += foodQuantity;
                        }
                    }
                }

                else if (command == "Feed")
                {
                    foreach (var element in animalsInfo.Values)
                    {
                        if (element.ContainsKey(animalName))
                        {
                            element[animalName] -= foodQuantity;

                            if (element[animalName] <= 0)
                            {
                                Console.WriteLine($"{animalName} was successfully fed");
                                element.Remove(animalName);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Animals:");
            foreach (var element in animalsInfo)
            {
                if (element.Value.Count > 0)
                {
                    foreach (var animal in element.Value)
                    {
                        string animalName = animal.Key;
                        int foodQuantity = animal.Value;
                        Console.WriteLine($" {animalName} -> {foodQuantity}g");
                    }

                }
            }

            Console.WriteLine("Areas with hungry animals:");
            foreach (var element in animalsInfo)
            {
                if (element.Value.Count > 0)
                {
                    Console.WriteLine($" {element.Key}: {element.Value.Count}");
                }
            }
        }
    }
}
