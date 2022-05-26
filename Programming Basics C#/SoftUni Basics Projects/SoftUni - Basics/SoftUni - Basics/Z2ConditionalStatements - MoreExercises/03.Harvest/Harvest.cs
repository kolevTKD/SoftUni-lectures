using System;

namespace _03.Harvest
{
    class Harvest
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapesPerSqM = double.Parse(Console.ReadLine());
            int litersWineNeeded = int.Parse(Console.ReadLine());
            int workersNum = int.Parse(Console.ReadLine());
            double percentForWine = 0.4;
            double kilosPerLiter = 2.5;
            double totalGrapes = area * grapesPerSqM;
            double litersWine = totalGrapes * percentForWine / kilosPerLiter;

            if (litersWine >= litersWineNeeded)
            {
                double litersForWorkers = litersWine - litersWineNeeded;
                double winePerWorker = litersForWorkers / workersNum;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(litersWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(litersForWorkers)} liters left -> {Math.Ceiling(winePerWorker)} liters per person.");
            }
            else
            {
                double litersLess = litersWineNeeded - litersWine;
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(litersLess)} liters wine needed.");
            }
        }
    }
}
