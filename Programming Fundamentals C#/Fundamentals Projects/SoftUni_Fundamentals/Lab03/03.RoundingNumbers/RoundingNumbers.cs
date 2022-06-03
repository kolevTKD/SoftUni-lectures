using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double[] roundedNum = new double[numbers.Length];

            for (int index = 0; index < numbers.Length; index++)
            {
                roundedNum[index] = (int)Math.Round(numbers[index], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{numbers[index]} => {roundedNum[index]}");
            }
        }
    }
}
