using System;

namespace _05.Pets
{
    class Pets
    {
        static void Main(string[] args)
        {
            int daysNum = int.Parse(Console.ReadLine());
            int foodLeft = int.Parse(Console.ReadLine());
            double dogFoodDayKg = double.Parse(Console.ReadLine());
            double catFoodDayKg = double.Parse(Console.ReadLine());
            double turtleFoodDayGrams = double.Parse(Console.ReadLine());
            int gramsConv = 1000;
            double turtleFoodDayKg = turtleFoodDayGrams / gramsConv;
            double dogFoodNeeded = dogFoodDayKg * daysNum;
            double catFoodNeeded = catFoodDayKg * daysNum;
            double turtleFoodNeeded = turtleFoodDayKg * daysNum;
            double totalFoodNeeded = dogFoodNeeded + catFoodNeeded + turtleFoodNeeded;
            bool isEnough = foodLeft >= totalFoodNeeded;

            if (isEnough)
            {
                double foodMore = Math.Floor(foodLeft - totalFoodNeeded);
                Console.WriteLine($"{foodMore} kilos of food left.");
            }

            else
            {
                double foodNeeded = Math.Ceiling(totalFoodNeeded - foodLeft);
                Console.WriteLine($"{foodNeeded} more kilos of food are needed.");
            }
        }
    }
}
