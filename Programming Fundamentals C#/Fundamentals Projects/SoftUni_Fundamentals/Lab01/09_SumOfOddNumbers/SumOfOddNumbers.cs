using System;

namespace _09_SumOfOddNumbers
{
    class SumOfOddNumbers
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            for(int i = 0; i < num; i++)
            {
                int currentNum = 1 + (i * 2);

                Console.WriteLine(currentNum);
                sum += currentNum;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
