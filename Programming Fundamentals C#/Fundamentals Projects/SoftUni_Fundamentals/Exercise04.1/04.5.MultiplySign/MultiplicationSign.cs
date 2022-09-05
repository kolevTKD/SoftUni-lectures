using System;
using System.Linq;

namespace _04._5.MultiplySign
{
    internal class MultiplicationSign
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            for (int num = 0; num < numbers.Length; num++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers[num] = number;
            }

            PosNegZero(numbers);
        }

        static void PosNegZero(int[] numbers)
        {
            string result = "";

            if (numbers.All(x => x > 0))
            {
                result = "positive";
            }

            else if (numbers.All(x => x < 0))
            {
                result = "negative";
            }

            else if (numbers.Where(x => x < 0).Take(3).Count() == 1)
            {
                result = "negative";
            }

            else if (numbers.Where(x => x > 0).Take(3).Count() == 1)
            {
                result = "positive";
            }

            else if (numbers.Any(x => x == 0))
            {
                result = "zero";
            }

            Console.WriteLine(result);
        }
    }
}
