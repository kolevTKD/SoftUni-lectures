using System;

namespace _01.Cinema
{
    class Cinema
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double premierePrice = 12;
            double normalPrice = 7.5;
            double discountPrice = 5;

            switch (type)
            {
                case "Premiere":
                    double totalPPrice = rows * columns * premierePrice;
                    Console.WriteLine($"{totalPPrice:f2} leva");
                    break;

                case "Normal":
                    double totalNPrice = rows * columns * normalPrice;
                    Console.WriteLine($"{totalNPrice:f2} leva");
                    break;

                case "Discount":
                    double totalDPrice = rows * columns * discountPrice;
                    Console.WriteLine($"{totalDPrice:f2} leva");
                    break;
            }
        }
    }
}
