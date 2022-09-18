using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class CupsAndBottles
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bottlesCapacity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(bottlesCapacity);
            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                

                int currentCup = cups.Peek();
                int currentBottle = bottles.Peek();

                while (currentCup > 0)
                {
                    if (currentCup > currentBottle)
                    {
                        currentCup -= currentBottle;
                        bottles.Pop();
                        currentBottle = bottles.Peek();
                    }

                    if (currentBottle >= currentCup)
                    {
                        cups.Dequeue();
                        bottles.Pop();
                        wastedWater += currentBottle - currentCup;
                        currentCup -= currentBottle;
                    }
                }
            }

            if (!bottles.Any())
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }

            else
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
