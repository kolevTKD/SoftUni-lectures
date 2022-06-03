using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    class SumEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sum = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] % 2 == 0)
                {
                    sum += numbers[index];
                }
            }
            Console.WriteLine(sum);
;        }
    }
}
