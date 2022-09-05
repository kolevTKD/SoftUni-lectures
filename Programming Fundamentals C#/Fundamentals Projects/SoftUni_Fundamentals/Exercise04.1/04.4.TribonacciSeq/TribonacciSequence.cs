using System;

namespace _04._4.TribonacciSeq
{
    internal class TribonacciSequence
    {
        public static int[] memo;
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            memo = new int[num + 1];
            TribSequence(num);
            PrintTrib(memo);
        }

        static int TribSequence(int num)
        {
            if (memo.Length == 2)
            {
                memo[0] = 1;
            }

            if (num <= 1)
            {
                return memo[num] = 1;
            }

            if (num == 2)
            {
                return memo[num] = TribSequence(num - 1) + TribSequence(num - 2);
            }

            if (memo[num] != 0)
            {
                return memo[num];
            }

            memo[num] = TribSequence(num - 1) + TribSequence(num - 2) + TribSequence(num - 3);
            return memo[num];

        }

        static void PrintTrib(int[] memo)
        {
            for (int index = 0; index < memo.Length - 1; index++)
            {
                Console.Write($"{memo[index]} ");
            }
        }
    }
}
