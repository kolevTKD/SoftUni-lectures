using System;
using System.Linq;
using System.Numerics;

namespace _02._2.FromLeftToTheRight
{
    class FromLeftToTheRight
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());

            for (int line = 1; line <= inputLines; line++)
            {
                string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                BigInteger leftNum = BigInteger.Parse(numbers[0]);
                BigInteger rightNum = BigInteger.Parse(numbers[1]);
                BigInteger biggerNum = BigInteger.Abs(BigInteger.Max(leftNum, rightNum));
                
                BigInteger sum = 0;

                while(biggerNum > 0)
                {
                    BigInteger currDigit = biggerNum % 10;
                    sum += currDigit;
                    biggerNum /= 10;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
