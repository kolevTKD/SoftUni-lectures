using System;

namespace _10.TopNumber
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());

            for (int currentNum = 1; currentNum <= endValue; currentNum++)
            {
                bool isDivisible = DivisibleSumBy8(currentNum);
                bool isContainingOdd = ContainsOddDigit(currentNum);

                if (isDivisible && isContainingOdd)
                {
                    Console.WriteLine(currentNum);
                }
            }
        }

        static bool DivisibleSumBy8(int number)
        {
            int divisibleNum = 0;

            while (number != 0)
            {
                divisibleNum += number % 10;
                number /= 10;
            }

            if (divisibleNum % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool ContainsOddDigit(int number)
        {
            while (number != 0)
            {
                int currentDigit = number % 10;

                if (currentDigit % 2 == 1)
                {
                    return true;
                }

                number /= 10;

            }

            return false;
        }
    }
}
