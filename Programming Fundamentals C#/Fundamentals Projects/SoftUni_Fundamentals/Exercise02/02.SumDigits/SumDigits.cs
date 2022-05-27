using System;

namespace _02.SumDigits
{
    class SumDigits
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            while (number != 0)
            {
                int currentDigit = number % 10;
                sum += currentDigit;
                number /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
