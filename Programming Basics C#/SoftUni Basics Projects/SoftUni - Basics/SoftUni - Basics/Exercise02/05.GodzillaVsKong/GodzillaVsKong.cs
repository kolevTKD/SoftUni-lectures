using System;

namespace _05.GodzillaVsKong
{
    class GodzillaVsKong
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double clothingPerStatistPrice = double.Parse(Console.ReadLine());
            double tenPercent = 0.1;
            double decorPrice = movieBudget * tenPercent;
            double clothingPrice = statists * clothingPerStatistPrice;
            double clothingDiscount = clothingPrice * tenPercent;
            double totalSum = decorPrice + clothingPrice;
            double remainder = movieBudget - totalSum;
            double neededMoney = movieBudget - totalSum;

            bool filming = movieBudget < totalSum;

            if (statists >= 150)
            {
                clothingPrice = clothingPrice - clothingDiscount;
                totalSum = decorPrice + clothingPrice;
                remainder = movieBudget - totalSum;
                neededMoney = movieBudget - totalSum;

                if (filming)
                {
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {Math.Abs(neededMoney):f2} leva more."); ;
                }

                else
                {
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {Math.Abs(remainder):f2} leva left.");
                }
            }

            else
            {
                if (filming)
                {
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {Math.Abs(neededMoney):f2} leva more."); ;
                }

                else
                {
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {Math.Abs(remainder):f2} leva left.");
                }
            }
        }
    }
}
