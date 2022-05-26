using System;

namespace _04.FishingBoat
{
    class FishingBoat
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermanCount = int.Parse(Console.ReadLine());

            double seasonalRent = 0;
            double discount = 0;
            double totalPrice = 0;
            double moneyLeft = 0;
            double moneyNeeded = 0;

            bool isValidSeason = season == "Spring" || season == "Summer" || season == "Autumn" || season == "Winter";
            bool isValidBudget = budget >= 1 && budget <= 8000;
            bool isEven = fishermanCount % 2 == 0;
            bool fishermansTenPercent = fishermanCount <= 6;
            bool fishermansFifteenPercent = fishermanCount >= 7 && fishermanCount <= 11;
            bool fishermansTwentyfivePercent = fishermanCount >= 12;

            if (isValidSeason && isValidBudget)
            {
                switch (season)
                {
                    case "Spring":
                        seasonalRent = 3000;
                        break;
                    case "Summer":
                    case "Autumn":
                        seasonalRent = 4200;
                        break;
                    case "Winter":
                        seasonalRent = 2600;
                        break;
                }
                if (fishermansTenPercent)
                {
                    discount = 0.9;
                }
                else if (fishermansFifteenPercent)
                {
                    discount = 0.85;
                }
                else if (fishermansTwentyfivePercent)
                {
                    discount = 0.75;
                }
                totalPrice = seasonalRent * discount;

                if (isEven && season != "Autumn")
                {
                    discount = 0.95;
                    totalPrice *= discount;
                }

                bool isEnough = budget >= totalPrice;

                if (isEnough)
                {
                    moneyLeft = budget - totalPrice;
                    Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
                }
                else
                {
                    moneyNeeded = totalPrice - budget;
                    Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva.");
                }
            }
        }
    }
}
