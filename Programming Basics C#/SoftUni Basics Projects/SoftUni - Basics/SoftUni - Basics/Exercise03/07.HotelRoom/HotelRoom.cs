using System;

namespace _07.HotelRoom
{
    class HotelRoom
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int stay = int.Parse(Console.ReadLine());
            double studioPricePerNight = 0;
            double appartmentPricePerNight = 0;
            double totalForStudio = 0;
            double totalForAppartment = 0;
            bool mayOctober = month == "May" || month == "October";
            bool juneSeptember = month == "June" || month == "September";
            bool julyAugust = month == "July" || month == "August";

            if (mayOctober)
            {
                studioPricePerNight = 50;
                appartmentPricePerNight = 65;
                if (stay > 7 && stay <= 14)
                {
                    studioPricePerNight *= 0.95;
                }
                else if (stay > 14)
                {
                    studioPricePerNight *= 0.7;
                }

            }

            else if (juneSeptember)
            {
                studioPricePerNight = 75.2;
                appartmentPricePerNight = 68.7;
                if (stay > 14)
                {
                    studioPricePerNight *= 0.8;
                }
            }

            else if (julyAugust)
            {
                studioPricePerNight = 76;
                appartmentPricePerNight = 77;
            }

            if (stay > 14)
            {
                appartmentPricePerNight *= 0.9;
            }

            totalForAppartment = appartmentPricePerNight * stay;
            totalForStudio = studioPricePerNight * stay;
            Console.WriteLine($"Apartment: {totalForAppartment:f2} lv.");
            Console.WriteLine($"Studio: {totalForStudio:f2} lv.");
        }
    }
}
