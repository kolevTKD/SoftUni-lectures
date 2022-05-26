using System;

namespace _02.BeerAndChips
{
    class BeerAndChips
    {
        static void Main(string[] args)
        {
            string fanName = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int bottlesBeer = int.Parse(Console.ReadLine());
            int packsChips = int.Parse(Console.ReadLine());
            double pricePerBottle = 1.2;
            double totalForBeers = bottlesBeer * pricePerBottle;
            double pricePerPack = totalForBeers * 0.45;
            double totalForChips = Math.Ceiling(packsChips * pricePerPack);
            double total = totalForBeers + totalForChips;

            if (budget >= total)
            {
                double left = budget - total;
                Console.WriteLine($"{fanName} bought a snack and has {left:f2} leva left.");
            }

            else
            {
                double needed = total - budget;
                Console.WriteLine($"{fanName} needs {needed:f2} more leva!");
            }
        }
    }
}
