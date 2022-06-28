using System;

namespace _01.TheHuntingGames
{
    class TheHuntngGames
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double totalEnergy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());
            double totalWater = days * playersCount * waterPerDay;
            double totalFood = days * playersCount * foodPerDay;

            for (int day = 1; day <= days; day++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                totalEnergy -= energyLoss;

                if (totalEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }

                if (day % 2 == 0)
                {
                    totalEnergy += totalEnergy * 0.05;
                    totalWater -= totalWater * 0.3;
                }

                if (day % 3 == 0)
                {
                    totalFood -= totalFood / playersCount;
                    totalEnergy += totalEnergy * 0.1;
                }
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {totalEnergy:f2} energy!");
        }
    }
}
