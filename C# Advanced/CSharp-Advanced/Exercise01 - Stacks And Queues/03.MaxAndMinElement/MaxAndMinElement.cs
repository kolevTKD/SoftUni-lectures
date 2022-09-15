using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaxAndMinElement
{
    internal class MaxAndMinElement
    {
        static void Main(string[] args)
        {
            int commandsNum = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < commandsNum; i++)
            {
                int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = commands[0];

                if (command == 1)
                {
                    int element = commands[1];
                    stack.Push(element);
                }

                else if (command == 2)
                {
                    stack.Pop();
                }

                else if (command == 3 || command == 4)
                {
                    if (stack.Count != 0)
                    {
                        if (command == 3)
                        {
                            Console.WriteLine(stack.Max());
                        }

                        else if (command == 4)
                        {
                            Console.WriteLine(stack.Min());
                        }
                    }
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine(String.Join(", ", stack));
            }
        }
    }
}
