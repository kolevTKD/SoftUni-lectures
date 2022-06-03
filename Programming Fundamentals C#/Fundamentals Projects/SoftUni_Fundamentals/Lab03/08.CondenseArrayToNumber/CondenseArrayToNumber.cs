using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class CondenseArrayToNumber
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] condensed = new int[numbers.Length - 1];


            while (numbers.Length > 1)
            {
                for (int index = 0; index < numbers.Length - 1; index++)
                {
                    condensed[index] = numbers[index] + numbers[index + 1];

                    if (index == numbers.Length - 2)
                    {
                        numbers = condensed;
                        condensed = new int[numbers.Length - 1];
                    }
                }
            }
            condensed = numbers;
            Console.WriteLine($"{condensed[0]}");
        }
    }
}
