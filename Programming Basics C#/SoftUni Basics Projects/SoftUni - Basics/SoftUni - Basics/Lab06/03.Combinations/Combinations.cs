using System;

namespace _03.Combinations
{
    class Combinations
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int sum = 0;
            int combinationsCounter = 0;

            for (int num1 = 0; num1 <= inputNum; num1++)
            {
                for (int num2 = 0; num2 <= inputNum; num2++)
                {
                    for (int num3 = 0; num3 <= inputNum; num3++)
                    {
                        sum = num1 + num2 + num3;
                        if (sum == inputNum)
                        {
                            combinationsCounter++;
                        }
                    }
                }
            }
            Console.WriteLine(combinationsCounter);
        }
    }
}
