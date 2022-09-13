using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.HotPotato
{
    internal class HotPotato
    {
        static void Main(string[] args)
        {
            Queue<string> children = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            int deathPasses = int.Parse(Console.ReadLine());
            int pass = 0;

            while (children.Count > 1)
            {
                pass++;
                string kid = children.Dequeue();

                if (pass == deathPasses)
                {
                    Console.WriteLine($"Removed {kid}");
                    pass = 0;
                    continue;
                }

                children.Enqueue(kid);
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
