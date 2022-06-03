using System;

namespace _02.PrintNumbersInReverseOrder
{
    class PrintNumbersInReverseOrder
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] numbers = new int[count];

            for (int index = 0; index < count; index++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers[index] = number;
            }

            for (int revIndex = numbers.Length - 1; revIndex >= 0; revIndex--)
            {
                Console.Write($"{numbers[revIndex]} ");
            }
        }
    }
}
