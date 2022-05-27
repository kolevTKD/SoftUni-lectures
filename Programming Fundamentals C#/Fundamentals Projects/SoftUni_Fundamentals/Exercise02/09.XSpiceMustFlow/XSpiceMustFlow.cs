using System;

namespace _09.XSpiceMustFlow
{
    class XSpiceMustFlow
    {
        static void Main(string[] args)
        {
            const int DROP = 10;
            const int PROFITABLE = 100;
            const int CONSUMPTION = 26;
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int totalGathered = 0;

            while (startingYield >= PROFITABLE)
            {
                int gatherPerDay = startingYield - CONSUMPTION;
                totalGathered += gatherPerDay;
                startingYield -= DROP;
                days++;

                if (startingYield < PROFITABLE)
                {
                    totalGathered -= CONSUMPTION;
                }
            }
            Console.WriteLine($"{days}");
            Console.WriteLine($"{totalGathered}");
        }
    }
}
