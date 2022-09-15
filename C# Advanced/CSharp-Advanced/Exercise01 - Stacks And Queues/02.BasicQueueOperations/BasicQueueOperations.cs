using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    internal class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] actions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int toEnqueue = actions[0];
            int toDequeue = actions[1];
            int toLook = actions[2];

            int[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            if (toEnqueue == toDequeue)
            {
                Console.WriteLine(0);

                return;
            }

            Queue<int> queue = new Queue<int>(elements);

            for (int i = 0; i < toDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(toLook))
            {
                Console.WriteLine("true");

                return;
            }

            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
