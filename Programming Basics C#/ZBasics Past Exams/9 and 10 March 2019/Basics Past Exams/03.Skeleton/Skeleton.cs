using System;

namespace _03.Skeleton
{
    class Skeleton
    {
        static void Main(string[] args)
        {
            int controlMinutes = int.Parse(Console.ReadLine());
            int controlSeconds = int.Parse(Console.ReadLine());
            double runwayLength = double.Parse(Console.ReadLine());
            int secondsPer100Meters = int.Parse(Console.ReadLine());
            double totalControlTime = controlMinutes * 60 + controlSeconds;
            double timesTimeReduced = runwayLength / 120;
            double totalTimeReduced = timesTimeReduced * 2.5;
            double marinTime = (runwayLength / 100) * secondsPer100Meters - totalTimeReduced;

            if (marinTime <= totalControlTime)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {marinTime:f3}.");
            }

            else
            {
                double timeNeeded = marinTime - totalControlTime;
                Console.WriteLine($"No, Marin failed! He was {timeNeeded:f3} second slower.");
            }
        }
    }
}
