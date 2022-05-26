using System;

namespace _10.OddEvenSum
{
    class OddEvenSum
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < a; i++)
            {
                bool evenNum = i % 2 == 0;
                bool oddNum = i % 2 == 1;

                if (evenNum)
                {
                    int even = int.Parse(Console.ReadLine());
                    sumEven += even;
                }

                if (oddNum)
                {
                    int odd = int.Parse(Console.ReadLine());
                    sumOdd += odd;
                }
            }

            if (sumEven == sumOdd)
            {
                Console.WriteLine($"Yes\nSum = {sumEven}");
            }

            else
            {
                int absDiff = Math.Abs(sumEven - sumOdd);
                Console.WriteLine($"No\nDiff = {absDiff}");
            }
        }
    }
}
