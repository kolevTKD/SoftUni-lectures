using System;

namespace _06.FlowerShop
{
    class FlowerShop
    {
        static void Main(string[] args)
        {
            int magnoliasNum = int.Parse(Console.ReadLine());
            int hyacinthNum = int.Parse(Console.ReadLine());
            int rosesNum = int.Parse(Console.ReadLine());
            int cactiesNum = int.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());
            double magnoliaPrice = 3.25;
            double hyacinthPrice = 4;
            double rosePrice = 3.5;
            double cactusPrice = 8;
            double debtsP = 0.95;
            double magnoliasTotal = magnoliasNum * magnoliaPrice;
            double hyacinthTotal = hyacinthNum * hyacinthPrice;
            double rosesTotal = rosesNum * rosePrice;
            double cactieTotal = cactiesNum * cactusPrice;
            double subTotal = magnoliasTotal + hyacinthTotal + rosesTotal + cactieTotal;
            double total = subTotal * debtsP;
            bool isEnough = presentPrice <= total;

            if (isEnough)
            {
                double moneyLeft = Math.Floor(total - presentPrice);
                Console.WriteLine($"She is left with {moneyLeft} leva.");
            }

            else
            {
                double moneyToBorrow = Math.Ceiling(presentPrice - total);
                Console.WriteLine($"She will have to borrow {moneyToBorrow} leva.");
            }
        }
    }
}
