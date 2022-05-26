using System;

namespace _02.PoundsToDollars
{
    class PoundsToDollars
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            double dollarRate = 1.31;
            double poundsToDollars = pounds * dollarRate;

            Console.WriteLine($"{poundsToDollars:f3}");
        }
    }
}
