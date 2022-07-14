using System;

namespace _02.Bikers
{
    class BikeRace
    {
        static void Main(string[] args)
        {
            int juniorRacers = int.Parse(Console.ReadLine());
            int seniorRacers = int.Parse(Console.ReadLine());
            string trackType = Console.ReadLine();
            string trail = "trail";
            string crossCountry = "cross-country";
            string downhill = "downhill";
            string road = "road";
            int totalRacers = juniorRacers + seniorRacers;
            double juniorTax = 0;
            double seniorTax = 0;

            if (trackType == trail)
            {
                juniorTax = 5.5;
                seniorTax = 7;
            }
            else if (trackType == crossCountry)
            {
                juniorTax = 8;
                seniorTax = 9.5;

                if (totalRacers >= 50)
                {
                    juniorTax *= 0.75;
                    seniorTax *= 0.75;
                }
            }
            else if (trackType == downhill)
            {
                juniorTax = 12.25;
                seniorTax = 13.75;
            }
            else if (trackType == road)
            {
                juniorTax = 20;
                seniorTax = 21.5;
            }

            double juniorTaxTotal = juniorRacers * juniorTax;
            double seniorTaxTotal = seniorRacers * seniorTax;
            double participationTaxTotal = juniorTaxTotal + seniorTaxTotal;
            double expenses = participationTaxTotal * 0.05;
            participationTaxTotal -= expenses;

            Console.WriteLine($"{participationTaxTotal:f2}");
        }
    }
}
