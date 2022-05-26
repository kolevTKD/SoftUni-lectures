using System;

namespace _07.FoodDelivery
{
    class FoodDelivery
    {
        static void Main(string[] args)
        {
            int chickenMenusAmount = int.Parse(Console.ReadLine());
            int fishMenusAmount = int.Parse(Console.ReadLine());
            int vegetarianMenusAmount = int.Parse(Console.ReadLine());

            double chickenMenuPrice = 10.35;
            double fishMenuPrice = 12.40;
            double vegetarianMenuPrice = 8.15;
            double twentyPercent = 0.2;
            double delivery = 2.50;

            double chickenMenusTotal = chickenMenusAmount * chickenMenuPrice;
            double fishMenusTotal = fishMenusAmount * fishMenuPrice;
            double vegetarianMenusTotal = vegetarianMenusAmount * vegetarianMenuPrice;
            double menusTotal = chickenMenusTotal + fishMenusTotal + vegetarianMenusTotal;
            double desert = menusTotal * twentyPercent;
            double orderTotal = menusTotal + desert + delivery;

            Console.WriteLine(orderTotal);
        }
    }
}
