using System;

namespace _03.NewHouse
{
    class NewHouse
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double percent = 0;
            double pricePerFlower = 0;
            double totalFlower = 0;
            double change = 0;
            double neededMoney = 0;

            bool isValidFlowerType = flowerType == "Roses" || flowerType == "Dahlias" ||
                flowerType == "Tulips" || flowerType == "Narcissus" || flowerType == "Gladiolus";

            if (isValidFlowerType)
            {
                switch (flowerType)
                {
                    case "Roses":
                        pricePerFlower = 5;
                        totalFlower = pricePerFlower * flowerCount;

                        if (flowerCount > 80)
                        {
                            percent = 0.9;
                            totalFlower *= percent;
                        }
                        break;

                    case "Dahlias":
                        pricePerFlower = 3.8;
                        totalFlower = pricePerFlower * flowerCount;

                        if (flowerCount > 90)
                        {
                            percent = 0.85;
                            totalFlower *= percent;
                        }
                        break;

                    case "Tulips":
                        pricePerFlower = 2.8;
                        totalFlower = pricePerFlower * flowerCount;

                        if (flowerCount > 80)
                        {
                            percent = 0.85;
                            totalFlower *= percent;
                        }
                        break;

                    case "Narcissus":
                        pricePerFlower = 3;
                        totalFlower = pricePerFlower * flowerCount;

                        if (flowerCount < 120)
                        {
                            percent = 1.15;
                            totalFlower *= percent;
                        }
                        break;

                    case "Gladiolus":
                        pricePerFlower = 2.5;
                        totalFlower = pricePerFlower * flowerCount;

                        if (flowerCount < 80)
                        {
                            percent = 1.2;
                            totalFlower *= percent;
                        }
                        break;
                }

            }
            bool isEnough = budget >= totalFlower;
            change = budget - totalFlower;
            neededMoney = totalFlower - budget;

            if (isEnough)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {change:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {neededMoney:f2} leva more.");
            }
        }
    }
}
