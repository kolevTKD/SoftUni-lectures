using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = bomb[0];
            int bombPower = bomb[1];

            for (int index = 0; index < numbers.Count; index++)
            {
                if (numbers[index] == bombNumber)
                {
                    int startIndex = Math.Max(0, index - bombPower);
                    int endIndex = Math.Min(numbers.Count - 1, index + bombPower);

                    for (int range = startIndex; range <= endIndex; range++)
                    {
                        numbers[range] = 0;
                    }
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
