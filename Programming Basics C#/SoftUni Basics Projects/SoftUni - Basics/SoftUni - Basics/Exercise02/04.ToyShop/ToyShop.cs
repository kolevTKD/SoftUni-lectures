using System;

namespace _04.ToyShop
{
    class ToyShop
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int talkingDolls = int.Parse(Console.ReadLine());
            int stuffedBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.60;
            double talkingDollsPrice = 3.00;
            double stuffedBearsPrice = 4.10;
            double minionsPrice = 8.20;
            double trucksPrice = 2.00;
            double discountPercent = 0.25;
            double rentTaxPercent = 0.1;

            double totalPuzzlePrice = puzzles * puzzlePrice;
            double totalTalkingDollsPrice = talkingDolls * talkingDollsPrice;
            double totalStuffedBearsPrice = stuffedBears * stuffedBearsPrice;
            double totalMinionsPrice = minions * minionsPrice;
            double totalTrucksPrice = trucks * trucksPrice;
            double subTotal = totalPuzzlePrice + totalTalkingDollsPrice + totalStuffedBearsPrice
                                                       + totalMinionsPrice + totalTrucksPrice;

            int sumOfToys = puzzles + talkingDolls + stuffedBears + minions + trucks;

            if (sumOfToys >= 50)
            {
                double discount = subTotal * discountPercent;
                double total = subTotal - discount;
                double rentTax = total * rentTaxPercent;
                double profit = total - rentTax;
                double leftovers = profit - excursionPrice;
                double absLeftovers = Math.Abs(leftovers);

                if (profit >= excursionPrice)
                {
                    Console.WriteLine($"Yes! {leftovers:f2} lv left.");
                }

                else if (profit < excursionPrice)
                {
                    Console.WriteLine($"Not enough money! {absLeftovers:f2} lv needed.");
                }
            }
            else if (sumOfToys < 50)
            {
                double rentTax = subTotal * rentTaxPercent;
                double profit = subTotal - rentTax;
                double leftovers = profit - excursionPrice;
                double absLeftovers = Math.Abs(leftovers);

                Console.WriteLine($"Not enough money! {absLeftovers:f2} lv needed.");
            }
    }
}
