using System;

namespace _09.SkiTrip
{
    class SkiTrip
    {
        static void Main(string[] args)
        {
            int daysOfStay = int.Parse(Console.ReadLine());
            string accommodation = Console.ReadLine();
            string rating = Console.ReadLine();

            int nightsOfStay = daysOfStay - 1;

            double roomForOnePrice = 18;
            double appartmentPrice = 25;
            double presidentApPrice = 35;
            double totalPrice = 0;
            double percent = 0;

            bool roomForOne = accommodation == "room for one person";
            bool apartment = accommodation == "apartment";
            bool presidentAppartment = accommodation == "president apartment";
            bool positiveRating = rating == "positive";
            bool negativeRating = rating == "negative";
            bool lessTenDays = daysOfStay < 10;
            bool tenFifteenDays = daysOfStay >= 10 && daysOfStay <= 15;
            bool moreFifteenDays = daysOfStay > 15;

            if (lessTenDays)
            {
                if (roomForOne)
                {
                    totalPrice = roomForOnePrice * nightsOfStay;
                }
                else if (apartment)
                {
                    percent = 0.7;
                    totalPrice = appartmentPrice * nightsOfStay * percent;
                }
                else if (presidentAppartment)
                {
                    percent = 0.9;
                    totalPrice = presidentApPrice * nightsOfStay * percent;
                }
            }
            else if (tenFifteenDays)
            {
                if (roomForOne)
                {
                    totalPrice = roomForOnePrice * nightsOfStay;
                }
                else if (apartment)
                {
                    percent = 0.65;
                    totalPrice = appartmentPrice * nightsOfStay * percent;
                }
                else if (presidentAppartment)
                {
                    percent = 0.85;
                    totalPrice = presidentApPrice * nightsOfStay * percent;
                }
            }
            else if (moreFifteenDays)
            {
                if (roomForOne)
                {
                    totalPrice = roomForOnePrice * nightsOfStay;
                }
                else if (apartment)
                {
                    percent = 0.5;
                    totalPrice = appartmentPrice * nightsOfStay * percent;
                }
                else if (presidentAppartment)
                {
                    percent = 0.8;
                    totalPrice = presidentApPrice * nightsOfStay * percent;
                }
            }
            if (positiveRating)
            {
                percent = 1.25;
                totalPrice *= percent;
            }
            else if (negativeRating)
            {
                percent = 0.9;
                totalPrice *= percent;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
