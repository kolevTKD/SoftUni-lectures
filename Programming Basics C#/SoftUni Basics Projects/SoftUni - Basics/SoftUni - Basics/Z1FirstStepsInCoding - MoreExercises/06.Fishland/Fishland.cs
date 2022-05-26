using System;

namespace _06.Fishland
{
    class Fishland
    {
        static void Main(string[] args)
        {
            double mackerelPricePerKilo = double.Parse(Console.ReadLine());
            double spratPricePerKilo = double.Parse(Console.ReadLine());
            double bonitoKilos = double.Parse(Console.ReadLine());
            double scadKilos = double.Parse(Console.ReadLine());
            double musselsKilo = double.Parse(Console.ReadLine());

            double bonitoPricePerKilo = mackerelPricePerKilo * 1.6;
            double scadPricePerKilo = spratPricePerKilo * 1.8;
            double musselsPricePerKilo = 7.5;

            double totalForBonito = bonitoKilos * bonitoPricePerKilo;
            double totalForScad = scadKilos * scadPricePerKilo;
            double totalForMussels = musselsKilo * musselsPricePerKilo;

            double total = totalForBonito + totalForScad + totalForMussels;

            Console.WriteLine($"{total:f2}");
        }
    }
}
