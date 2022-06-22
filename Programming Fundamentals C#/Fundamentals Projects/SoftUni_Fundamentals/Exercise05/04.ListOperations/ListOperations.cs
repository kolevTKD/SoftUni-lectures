using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class ListOperations
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string end = "End";

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];

                if (command == end)
                {
                    break;
                }

                if (command == "Add")
                {
                    int number = int.Parse(commands[1]);
                    numbers.Add(number);
                }

                else if (command == "Insert")
                {
                    int number = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);

                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, number);
                }

                else if (command == "Remove")
                {
                    int removeIndex = int.Parse(commands[1]);

                    if (removeIndex < 0 || removeIndex >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(removeIndex);
                }

                else if (command == "Shift")
                {
                    int count = int.Parse(commands[2]);

                    if (commands[1] == "left")
                    {
                        for (int index = 0; index < count; index++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }

                    else if (commands[1] == "right")
                    {
                        for (int index = 0; index < count; index++)
                        {
                            numbers.Insert(0, numbers[numbers.Count - 1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
