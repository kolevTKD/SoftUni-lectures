using System;

namespace _04.Vegetables
{
    class VegetableMarket
    {
        static void Main(string[] args)
        {
            double pricePerKiloVegetables = double.Parse(Console.ReadLine());
            double pricePerKiloFruits = double.Parse(Console.ReadLine());
            double totalKilosVegetables = double.Parse(Console.ReadLine());
            double totalKilosFruits = double.Parse(Console.ReadLine());
            double euro = 1.94;
            double vegetablesPrice = pricePerKiloVegetables * totalKilosVegetables;
            double fruitsPrice = pricePerKiloFruits * totalKilosFruits;
            double total = (vegetablesPrice + fruitsPrice) / euro;

            Console.WriteLine($"{total:f2}");
        }
    }
}
