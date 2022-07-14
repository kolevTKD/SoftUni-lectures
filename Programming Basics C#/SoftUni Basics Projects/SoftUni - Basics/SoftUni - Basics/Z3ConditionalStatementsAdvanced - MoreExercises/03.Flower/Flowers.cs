using System;

namespace _03.Flower
{
    class Flowers
    {
        static void Main(string[] args)
        {
            int chrysanthemumsBought = int.Parse(Console.ReadLine());
            int rosesBought = int.Parse(Console.ReadLine());
            int tulipsBought = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char holiday = char.Parse(Console.ReadLine());
            string spring = "Spring";
            string summer = "Summer";
            string autumn = "Autumn";
            string winter = "Winter";
            char yes = 'Y';
            double chrysanthemumPrice = 0;
            double rosePrice = 0;
            double tulipPrice = 0;
            double arranging = 2;
            int totalFlowersBought = chrysanthemumsBought + rosesBought + tulipsBought;

            if (season == spring || season == summer)
            {
                chrysanthemumPrice = 2;
                rosePrice = 4.1;
                tulipPrice = 2.5;
            }

            else if (season == autumn || season == winter)
            {
                chrysanthemumPrice = 3.75;
                rosePrice = 4.5;
                tulipPrice = 4.15;
            }

            if (holiday == yes)
            {
                chrysanthemumPrice *= 1.15;
                rosePrice *= 1.15;
                tulipPrice *= 1.15;
            }

            double totalForChrysnthemums = chrysanthemumsBought * chrysanthemumPrice;
            double totalForRoses = rosesBought * rosePrice;
            double totalForTulips = tulipsBought * tulipPrice;
            double bouquetPrice = totalForChrysnthemums + totalForRoses + totalForTulips;

            if (season == spring)
            {
                if (tulipsBought >= 7)
                {
                    bouquetPrice *= 0.95;
                }
            }

            else if (season == winter)
            {
                if (rosesBought >= 10)
                {
                    bouquetPrice *= 0.9;
                }
            }

            if (totalFlowersBought > 20)
            {
                bouquetPrice *= 0.8;
            }

            bouquetPrice += arranging;
            Console.WriteLine($"{bouquetPrice:f2}");
        }
    }
}
