using System;

namespace _05.Journey
{
    class Journey
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double percent = 0;
            double spentSum = 0;
            bool summer = season == "summer";
            bool winter = season == "winter";
            bool isValidBudget = budget >= 10 && budget <= 5000;
            bool isValidSeason = summer || winter;
            bool budgetLessHundred = budget <= 100;
            bool budgetLessThousand = budget <= 1000 && budget > 100;
            bool budgetGreaterThousand = budget > 1000;
            string destination = null;
            string stay = null;

            if (isValidBudget && isValidSeason)
            {
                if (budgetLessHundred)
                {
                    destination = "Bulgaria";
                    switch (season)
                    {
                        case "summer":
                            percent = 0.3;
                            stay = "Camp";
                            break;
                        case "winter":
                            percent = 0.7;
                            stay = "Hotel";
                            break;
                    }
                }
                else if (budgetLessThousand)
                {
                    destination = "Balkans";
                    switch (season)
                    {
                        case "summer":
                            percent = 0.4;
                            stay = "Camp";
                            break;
                        case "winter":
                            percent = 0.8;
                            stay = "Hotel";
                            break;
                    }
                }
                else if (budgetGreaterThousand)
                {
                    destination = "Europe";
                    switch (season)
                    {
                        case "summer":
                        case "winter":
                            percent = 0.9;
                            stay = "Hotel";
                            break;
                    }
                }
                spentSum = budget * percent;
                Console.WriteLine($"Somewhere in {destination}");
                Console.WriteLine($"{stay} - {spentSum:f2}");
            }
        }
    }
}
