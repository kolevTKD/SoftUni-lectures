using System;

namespace _01.EasterLunch
{
    class EasterLunch
    {
        static void Main(string[] args)
        {
            double easterBreadPrice = 3.2;
            double pricePerEggshell = 4.35;
            double pricePerKgCookies = 5.4;
            double eggPaintPrice = 0.15;

            int easterBreadsNum = int.Parse(Console.ReadLine());
            int eggshellsNum = int.Parse(Console.ReadLine());
            int cookiesKg = int.Parse(Console.ReadLine());
            int totalEggsNum = eggshellsNum * 12;

            double easterBreadTotal = easterBreadPrice * easterBreadsNum;
            double eggshellsTotal = pricePerEggshell * eggshellsNum;
            double cookiesTotal = pricePerKgCookies * cookiesKg;
            double eggPaintTotal = eggPaintPrice * totalEggsNum;

            double total = easterBreadTotal + eggshellsTotal + cookiesTotal + eggPaintTotal;

            Console.WriteLine($"{total:f2}");
        }
    }
}
