using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class MovingTarget
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = commands[0];
            int index = int.Parse(commands[1]);
            string end = "End";

            while (command != end)
            {
                index = int.Parse(commands[1]);
                int token = int.Parse(commands[2]);

                if (command == "Shoot")
                {
                    Shoot(targets, index, token);
                }

                else if (command == "Add")
                {
                    Add(targets, index, token);
                }

                else if (command == "Strike")
                {
                    Strike(targets, index, token);
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = commands[0];
            }

            Console.WriteLine(string.Join('|', targets));
        }

        static List<int> Shoot(List<int> targets, int index, int power)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets[index] -= power;

                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }

            return targets;
        }

        static List<int> Add(List<int> targets, int index, int value)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, value);
            }

            else
            {
                Console.WriteLine("Invalid placement!");
            }

            return targets;
        }

        static List<int> Strike(List<int> targets, int index, int radius)
        {
            if (index - radius < 0 || index + radius >= targets.Count)
            {
                Console.WriteLine("Strike missed!");
            }

            else
            {
                targets.RemoveRange(index - radius, radius * 2 + 1);
            }

            return targets;
        }
    }
}
