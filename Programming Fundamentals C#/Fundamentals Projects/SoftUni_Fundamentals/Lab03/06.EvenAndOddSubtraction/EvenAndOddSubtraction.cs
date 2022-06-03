using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class EvenAndOddSubtraction
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int evenSum = 0;
            int oddSum = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] % 2 == 0)
                {
                    evenSum += numbers[index];
                }

                else
                {
                    oddSum += numbers[index];
                }
            }

            int result = evenSum - oddSum;
            Console.WriteLine(result);
        }
    }
}
