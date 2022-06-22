using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            for (int index = 0; index < commands; index++)
            {
                string[] command = Console.ReadLine().Split();
                string name = command[0];

                if (command[2] == "going!")
                {
                    if (!names.Contains(name))
                    {
                        names.Add(name);
                    }

                    else if (names.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }

                else if (command[2] == "not")
                {
                    if (!names.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }

                    else if (names.Contains(name))
                    {
                        names.Remove(name);
                    }
                }
            }

            for (int index = 0; index < names.Count; index++)
            {
                Console.WriteLine(names[index]);
            }
        }
    }
}
