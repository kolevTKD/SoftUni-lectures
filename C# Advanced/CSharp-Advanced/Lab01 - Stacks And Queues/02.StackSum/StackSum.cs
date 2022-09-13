using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class StackSum
    {
        static void Main(string[] args)
        {
            Stack<int> summed = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            while (true)
            {
                string[] commands = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "end")
                {
                    break;
                }

                string command = commands[0];

                if (command == "add")
                {
                    summed.Push(int.Parse(commands[1]));
                    summed.Push(int.Parse(commands[2]));
                }

                else if (command == "remove")
                {
                    int toPop = int.Parse(commands[1]);

                    if (toPop <= summed.Count)
                    {
                        for (int i = 0; i < toPop; i++)
                        {
                            summed.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {summed.Sum()}");
        }
    }
}
