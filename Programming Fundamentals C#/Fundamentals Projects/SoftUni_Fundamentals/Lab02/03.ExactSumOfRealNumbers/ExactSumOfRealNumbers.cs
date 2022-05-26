using System;

namespace _03.ExactSumOfRealNumbers
{
    class ExactSumOfRealNumbers
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int number = 1; number <= count; number++)
            {
                decimal newNumber = decimal.Parse(Console.ReadLine());
                sum += newNumber;
            }

            Console.WriteLine(sum);
        }
    }
}
