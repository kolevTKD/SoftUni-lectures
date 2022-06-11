using System;

namespace _10.MultiplyEvensByOdds
{
    class MultiplyEvensByOdds
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            inputNumber = Math.Abs(inputNumber);
            int evenSum = GetSumOfEvenDigits(inputNumber);
            int oddSum = GetSumOfOddDigits(inputNumber);
            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);
            Console.WriteLine(result);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int digits = number;
            int evenSum = 0;

            while (digits != 0)
            {
                int currentDigit = digits % 10;

                if (currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }

                digits /= 10;
            }
            return evenSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int digits = number;
            int oddSum = 0;

            while (digits != 0)
            {
                int currentDigit = digits % 10;

                if (currentDigit % 2 == 1)
                {
                    oddSum += currentDigit;
                }

                digits /= 10;
            }
            return oddSum;
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            int result = evenSum * oddSum;
            return result;
        }
    }
}
