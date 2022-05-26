using System;

namespace _08.BasketballEquipment
{
    class BasketballEquipment
    {
        static void Main(string[] args)
        {
            double yearTax = double.Parse(Console.ReadLine());

            double fortyPercent = 0.4;
            double twentyPercent = 0.2;
            double twentyFivePercent = 0.25;

            double sneakersPrice = yearTax - (yearTax * fortyPercent);
            double outfitPrice = sneakersPrice - (sneakersPrice * twentyPercent);
            double ballPrice = outfitPrice * twentyFivePercent;
            double accessories = ballPrice * twentyPercent;
            double total = yearTax + sneakersPrice + outfitPrice + ballPrice + accessories;

            Console.WriteLine(total);
        }
    }
}
