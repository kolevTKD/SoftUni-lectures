using System;

namespace _03.SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            while (sum != num)
            {
                int newNum = int.Parse(Console.ReadLine());
                sum += newNum;

                if (sum >= num)
                {
                    Console.WriteLine(sum);
                    break;
                }
            }
        }
    }
}
