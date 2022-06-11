using System;
using System.Linq;

namespace _05.TopIntegers
{
    class TopIntegers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            for (int index = 0; index <= numbers.Length - 1; index++)
            {
                bool isTopInt = true;

                for (int i = index + 1; i < numbers.Length; i++)
                {
                    if (numbers[index] <= numbers[i])
                    {
                        isTopInt = false;
                        break;
                    }
                }

                if (isTopInt)
                {
                    Console.Write($"{numbers[index]} ");
                }
            }
        }
    }
}
