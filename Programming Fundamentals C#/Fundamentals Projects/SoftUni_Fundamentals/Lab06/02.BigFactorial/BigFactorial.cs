using System;
using System.Numerics;

namespace _02.BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;

            for (int i = 2; i <= inputNum; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
