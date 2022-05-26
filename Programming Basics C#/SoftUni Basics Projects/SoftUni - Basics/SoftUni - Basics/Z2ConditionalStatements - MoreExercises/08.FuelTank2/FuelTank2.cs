using System;

namespace _08.FuelTank2
{
    class FuelTank2
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelQuantity = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();
            string gasoline = "Gasoline";
            string diesel = "Diesel";
            string gas = "Gas";
            string yes = "Yes";
            string no = "No";
            double fuelPrice = 0;
            double fuelDiscount = 0;
            double total = 0;
            bool haveCard = clubCard == yes;
            bool btwn20And25 = fuelQuantity >= 20 && fuelQuantity <= 25;
            bool over25 = fuelQuantity > 25;

            if (haveCard)
            {
                if (fuelType == gasoline)
                {
                    fuelPrice = 2.22;
                    fuelDiscount = 0.18;
                }

                else if (fuelType == diesel)
                {
                    fuelPrice = 2.33;
                    fuelDiscount = 0.12;
                }

                else if (fuelType == gas)
                {
                    fuelPrice = 0.93;
                    fuelDiscount = 0.08;
                }
                fuelPrice -= fuelDiscount;
                total = fuelQuantity * fuelPrice;

            }

            else
            {
                if (fuelType == gasoline)
                {
                    fuelPrice = 2.22;
                }

                else if (fuelType == diesel)
                {
                    fuelPrice = 2.33;
                }

                else if (fuelType == gas)
                {
                    fuelPrice = 0.93;
                }
                total = fuelQuantity * fuelPrice;
            }

            if (btwn20And25)
            {
                total *= 0.92;
            }

            else if (over25)
            {
                total *= 0.9;
            }
            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
