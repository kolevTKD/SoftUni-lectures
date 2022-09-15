using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBotique
{
    internal class FashionBotique
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(clothesInBox);
            int clothesSum = 0;
            int racksUsed = 1;

            while (clothes.Count > 0)
            {
                clothesSum += clothes.Peek();

                if (clothesSum < rackCapacity)
                {
                    clothes.Pop();
                }

                else if (clothesSum == rackCapacity)
                {
                    clothes.Pop();

                    if (clothes.Any())
                    {
                        racksUsed++;
                        clothesSum = 0;
                    }
                }

                else
                {
                    racksUsed++;
                    clothesSum = 0;
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
