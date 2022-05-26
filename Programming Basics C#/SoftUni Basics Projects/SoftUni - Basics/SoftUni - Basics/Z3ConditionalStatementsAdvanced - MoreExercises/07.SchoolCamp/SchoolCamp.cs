using System;

namespace _07.SchoolCamp
{
    class SchoolCamp
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int studentsNum = int.Parse(Console.ReadLine());
            int nightsStay = int.Parse(Console.ReadLine());
            string winter = "Winter";
            string spring = "Spring";
            string summer = "Summer";
            string boys = "boys";
            string girls = "girls";
            string mixed = "mixed";
            string sport = null;
            double price = 0;
            double totalPrice = 0;

            if (season == winter)
            {
                if (groupType == boys || groupType == girls)
                {
                    price = 9.6;
                }

                else if (groupType == mixed)
                {
                    price = 10;
                }

                if (groupType == boys)
                {
                    sport = "Judo";
                }

                else if (groupType == girls)
                {
                    sport = "Gymnastics";
                }

                else if (groupType == mixed)
                {
                    sport = "Ski";
                }
            }

            else if (season == spring)
            {
                if (groupType == boys || groupType == girls)
                {
                    price = 7.2;
                }

                else if (groupType == mixed)
                {
                    price = 9.5;
                }

                if (groupType == boys)
                {
                    sport = "Tennis";
                }

                else if (groupType == girls)
                {
                    sport = "Athletics";
                }

                else if (groupType == mixed)
                {
                    sport = "Cycling";
                }
            }

            else if (season == summer)
            {
                if (groupType == boys || groupType == girls)
                {
                    price = 15;
                }

                else if (groupType == mixed)
                {
                    price = 20;
                }

                if (groupType == boys)
                {
                    sport = "Football";
                }

                else if (groupType == girls)
                {
                    sport = "Volleyball";
                }

                else if (groupType == mixed)
                {
                    sport = "Swimming";
                }
            }

            totalPrice = studentsNum * nightsStay * price;

            if (studentsNum >= 50)
            {
                totalPrice *= 0.5;
            }

            else if (studentsNum >= 20 && studentsNum < 50)
            {
                totalPrice *= 0.85;
            }

            else if (studentsNum >= 10 && studentsNum < 20)
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"{sport} {totalPrice:f2} lv.");
        }
    }
}
