using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] actions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int toPush = actions[0];
            int toPop = actions[1];
            int toLook = actions[2];

            int[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(elements);

            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(stack.Count);

                return;
            }

            else if (stack.Contains(toLook))
            {
                Console.WriteLine("true");

                return;
            }

            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
