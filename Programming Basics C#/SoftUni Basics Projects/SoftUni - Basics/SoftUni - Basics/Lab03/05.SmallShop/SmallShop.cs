using System;

namespace _05.SmallShop
{
    class SmallShop
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            bool sofia = city == "Sofia";
            bool plovdiv = city == "Plovdiv";
            bool varna = city == "Varna";
            bool coffee = product == "coffee";
            bool water = product == "water";
            bool beer = product == "beer";
            bool sweets = product == "sweets";
            bool peanuts = product == "peanuts";

            if (sofia)
            {
                double coffeePrice = 0.5;
                double waterPrice = 0.8;
                double beerPrice = 1.20;
                double sweetsPrice = 1.45;
                double peanutsPrice = 1.60;
                double coffeeTotal = coffeePrice * quantity;
                double waterTotal = waterPrice * quantity;
                double beerTotal = beerPrice * quantity;
                double sweetsTotal = sweetsPrice * quantity;
                double peanutsTotal = peanutsPrice * quantity;

                if (coffee)
                {
                    Console.WriteLine(coffeeTotal);
                }

                else if (water)
                {
                    Console.WriteLine(waterTotal);
                }

                else if (beer)
                {
                    Console.WriteLine(beerTotal);
                }

                else if (sweets)
                {
                    Console.WriteLine(sweetsTotal);
                }

                else if (peanuts)
                {
                    Console.WriteLine(peanutsTotal);
                }
            }
            else if (plovdiv)
            {
                double coffeePrice = 0.4;
                double waterPrice = 0.7;
                double beerPrice = 1.15;
                double sweetsPrice = 1.30;
                double peanutsPrice = 1.50;
                double coffeeTotal = coffeePrice * quantity;
                double waterTotal = waterPrice * quantity;
                double beerTotal = beerPrice * quantity;
                double sweetsTotal = sweetsPrice * quantity;
                double peanutsTotal = peanutsPrice * quantity;

                if (coffee)
                {
                    Console.WriteLine(coffeeTotal);
                }

                else if (water)
                {
                    Console.WriteLine(waterTotal);
                }

                else if (beer)
                {
                    Console.WriteLine(beerTotal);
                }

                else if (sweets)
                {
                    Console.WriteLine(sweetsTotal);
                }

                else if (peanuts)
                {
                    Console.WriteLine(peanutsTotal);
                }

            }
            else if (varna)
            {
                double coffeePrice = 0.45;
                double waterPrice = 0.7;
                double beerPrice = 1.10;
                double sweetsPrice = 1.35;
                double peanutsPrice = 1.55;
                double coffeeTotal = coffeePrice * quantity;
                double waterTotal = waterPrice * quantity;
                double beerTotal = beerPrice * quantity;
                double sweetsTotal = sweetsPrice * quantity;
                double peanutsTotal = peanutsPrice * quantity;

                if (coffee)
                {
                    Console.WriteLine(coffeeTotal);
                }

                else if (water)
                {
                    Console.WriteLine(waterTotal);
                }

                else if (beer)
                {
                    Console.WriteLine(beerTotal);
                }

                else if (sweets)
                {
                    Console.WriteLine(sweetsTotal);
                }

                else if (peanuts)
                {
                    Console.WriteLine(peanutsTotal);
                }
            }
        }
    }
}
