using System;

namespace GoldMine
{
    class GoldMine
    {
        static void Main(string[] args)
        {
            int locationsNum = int.Parse(Console.ReadLine());
            double totalGold = 0;
            double avgPerDay = 0;

            for(int location = 1; location <= locationsNum; location++)
            {
                double avgExpectedPerDay = double.Parse(Console.ReadLine());
                int daysDigOnLocation = int.Parse(Console.ReadLine());

                for(int day = 1; day <= daysDigOnLocation; day++)
                {
                    double goldPerDay = double.Parse(Console.ReadLine());
                    totalGold += goldPerDay;
                }
                avgPerDay = totalGold / daysDigOnLocation;
                totalGold = 0;

                if(avgExpectedPerDay <= avgPerDay)
                {
                    Console.WriteLine($"Good job! Average gold per day: {avgPerDay:f2}.");
                }
                else if(avgExpectedPerDay > avgPerDay)
                {
                    double nededGold = avgExpectedPerDay - avgPerDay;
                    Console.WriteLine($"You need {nededGold:f2} gold.");
                }
            }
        }
    }
}
