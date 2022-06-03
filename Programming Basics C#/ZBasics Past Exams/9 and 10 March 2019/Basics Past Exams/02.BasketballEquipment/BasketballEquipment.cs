using System;

namespace _02.BasketballEquipment
{
    class BasketballEquipment
    {
        static void Main(string[] args)
        {
            int taxPerYear = int.Parse(Console.ReadLine());
            double sneakersPrice = taxPerYear * 0.6;
            double equipPrice = sneakersPrice * 0.8;
            double ballPrice = equipPrice / 4;
            double accesoariesPrice = ballPrice / 5;
            double total = taxPerYear + sneakersPrice + equipPrice + ballPrice + accesoariesPrice;

            Console.WriteLine($"{total:f2}");

        }
    }
}
