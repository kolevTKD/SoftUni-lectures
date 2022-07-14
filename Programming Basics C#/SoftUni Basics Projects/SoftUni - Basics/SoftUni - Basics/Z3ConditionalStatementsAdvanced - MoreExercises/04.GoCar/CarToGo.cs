using System;

namespace _04.GoCar
{
    class CarToGo
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string carClass = null;
            string carType = null;
            string summer = "Summer";
            string winter = "Winter";
            string economy = "Economy class";
            string compact = "Compact class";
            string lux = "Luxury class";
            string cabrio = "Cabrio";
            string jeep = "Jeep";
            double carPrice = 0;

            if (budget <= 100)
            {
                carClass = economy;

                if (season == summer)
                {
                    carType = cabrio;
                    carPrice = budget * 0.35;
                }

                else if (season == winter)
                {
                    carType = jeep;
                    carPrice = budget * 0.65;
                }
            }

            else if (budget > 100 && budget <= 500)
            {
                carClass = compact;

                if (season == summer)
                {
                    carType = cabrio;
                    carPrice = budget * 0.45;
                }

                else if (season == winter)
                {
                    carType = jeep;
                    carPrice = budget * 0.8;
                }
            }

            else if (budget > 500)
            {
                carClass = lux;
                carType = jeep;
                carPrice = budget * 0.9;
            }

            Console.WriteLine(carClass);
            Console.WriteLine($"{carType} - {carPrice:f2}");
        }
    }
}
