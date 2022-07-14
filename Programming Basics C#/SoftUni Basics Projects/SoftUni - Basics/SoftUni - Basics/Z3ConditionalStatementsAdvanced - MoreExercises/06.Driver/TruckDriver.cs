using System;

namespace _06.Driver
{
    class TruckDriver
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmPerMonth = double.Parse(Console.ReadLine());
            string spring = "Spring";
            string summer = "Summer";
            string autumn = "Autumn";
            string winter = "Winter";
            double payPerKm = 0;
            double totalPayment = 0;
            double tax = 0.9;

            if (kmPerMonth <= 5000)
            {
                if (season == spring || season == autumn)
                {
                    payPerKm = 0.75;
                }

                else if (season == summer)
                {
                    payPerKm = 0.9;
                }

                else if (season == winter)
                {
                    payPerKm = 1.05;
                }
            }

            else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
            {
                if (season == spring || season == autumn)
                {
                    payPerKm = 0.95;
                }

                else if (season == summer)
                {
                    payPerKm = 1.1;
                }

                else if (season == winter)
                {
                    payPerKm = 1.25;
                }
            }

            else if (kmPerMonth > 10000 && kmPerMonth <= 20000)
            {
                payPerKm = 1.45;
            }

            totalPayment = 4 * (kmPerMonth * payPerKm);
            totalPayment *= tax;

            Console.WriteLine($"{totalPayment:f2}");
        }
    }
}
