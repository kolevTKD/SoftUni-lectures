using System;

namespace _03._3.RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        public static long[] memo;
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            memo = new long[num + 1];

            Console.WriteLine(GetFib(num - 1));
        }

        static long GetFib(int num)
        {
            if (num <= 1)
            {
                return memo[num] =  1;
            }

            if (memo[num] != 0)
            {
                return memo[num];
            }

            memo[num] = GetFib(num - 1) + GetFib(num - 2);

            return memo[num];

        }
    }
}
