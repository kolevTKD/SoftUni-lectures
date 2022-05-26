using System;

namespace _05.SuppliesForSchool
{
    class SuppliesForSchool
    {
        static void Main(string[] args)
        {
            int penPacks = int.Parse(Console.ReadLine());
            int markerPacks = int.Parse(Console.ReadLine());
            int cleanerLiters = int.Parse(Console.ReadLine());
            int discountPercent = int.Parse(Console.ReadLine());

            double discountDevider = 100;
            double penPacksPrice = 5.80;
            double markerPacksPrice = 7.20;
            double cleanerPerLiterPrice = 1.20;

            double pens = penPacks * penPacksPrice;
            double markers = markerPacks * markerPacksPrice;
            double cleaner = cleanerLiters * cleanerPerLiterPrice;
            double subTotal = pens + markers + cleaner;
            double discount = discountPercent / discountDevider;
            double total = subTotal - (subTotal * discount);

            Console.WriteLine(total);
        }
    }
}
