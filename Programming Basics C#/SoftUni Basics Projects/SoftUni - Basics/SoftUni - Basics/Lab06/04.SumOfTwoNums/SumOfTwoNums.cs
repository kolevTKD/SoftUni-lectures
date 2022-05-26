using System;

namespace _04.SumOfTwoNums
{
    class SumOfTwoNums
    {
        static void Main(string[] args)
        {
            int beginning = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int combination = 0;

            for (int num1 = beginning; num1 <= end; num1++)
            {
                for (int num2 = beginning; num2 <= end; num2++)
                {
                    int sum = num1 + num2;
                    combination++;

                    if (sum == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combination} ({num1} + {num2} = {magicNum})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{combination} combinations - neither equals {magicNum}");
        }
    }
}
