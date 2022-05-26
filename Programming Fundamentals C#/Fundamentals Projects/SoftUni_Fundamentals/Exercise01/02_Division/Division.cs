using System;

namespace _02_Division
{
    class Division
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int divisibleNum = 0;

            if (inputNum % 10 == 0)
            {
                divisibleNum = 10;
            }

            else if (inputNum % 7 == 0)
            {
                divisibleNum = 7;
            }

            else if (inputNum % 6 == 0)
            {
                divisibleNum = 6;
            }

            else if (inputNum % 3 == 0)
            {
                divisibleNum = 3;
            }

            else if (inputNum % 2 == 0)
            {
                divisibleNum = 2;
            }

            if (divisibleNum == 0)
            {
                Console.WriteLine("Not divisible");
            }

            else
            {
                Console.WriteLine($"The number is divisible by {divisibleNum}");
            }
        }
    }
}
