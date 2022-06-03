using System;

namespace _01.TennisEquipment
{
    class TennisEquipment
    {
        static void Main(string[] args)
        {
            double tennisRocketPrice = double.Parse(Console.ReadLine());
            int rocketsNum = int.Parse(Console.ReadLine());
            int pairsOfShoes = int.Parse(Console.ReadLine());
            double totalForRockets = tennisRocketPrice * rocketsNum;
            double pricePerPairShoes = tennisRocketPrice / 6;
            double totalForShoes = pricePerPairShoes * pairsOfShoes;
            double total = totalForRockets + totalForShoes;
            double priceForAccesoaries = total * 0.2;
            total += priceForAccesoaries;
            double priceForDjokovic = total / 8;
            double priceForSponsors = total * 7 / 8;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceForDjokovic)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(priceForSponsors)}");
        }
    }
}
