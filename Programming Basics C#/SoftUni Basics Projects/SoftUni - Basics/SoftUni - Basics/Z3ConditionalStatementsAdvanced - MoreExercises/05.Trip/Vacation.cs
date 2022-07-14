using System;

namespace _05.Trip
{
    class Vacation
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string summer = "Summer";
            string winter = "Winter";
            string camp = "Camp";
            string hut = "Hut";
            string hotel = "Hotel";
            string alaska = "Alaska";
            string morocco = "Morocco";
            string location = null;
            string stay = null;
            double price = 0;

            if (budget <= 1000)
            {
                stay = camp;

                if (season == summer)
                {
                    location = alaska;
                    price = budget * 0.65;
                }

                else if (season == winter)
                {
                    location = morocco;
                    price = budget * 0.45;
                }
            }

            else if (budget > 1000 && budget <= 3000)
            {
                stay = hut;

                if (season == summer)
                {
                    location = alaska;
                    price = budget * 0.8;
                }

                else if (season == winter)
                {
                    location = morocco;
                    price = budget * 0.6;
                }
            }

            else if (budget > 3000)
            {
                stay = hotel;

                if (season == summer)
                {
                    location = alaska;
                }

                else if (season == winter)
                {
                    location = morocco;
                }
                price = budget * 0.9;
            }

            Console.WriteLine($"{location} - {stay} - {price:f2}");
        }
    }
}
