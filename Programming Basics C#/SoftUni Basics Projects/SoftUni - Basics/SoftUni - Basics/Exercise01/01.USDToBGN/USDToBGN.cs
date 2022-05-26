using System;

namespace _01.USDToBGN
{
    class USDToBGN
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double usdValue = 1.79549;
            double bgn = usd * usdValue;

            Console.WriteLine(bgn);
        }
    }
}
