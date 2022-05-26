using System;

namespace _09.YardGreening
{
    class YardGreening
    {
        static void Main(string[] args)
        {
            double sqMeters = double.Parse(Console.ReadLine());

            double sqMeterPrice = 7.61;
            double discount = 0.18;

            double greening = sqMeters * sqMeterPrice;
            double disPrice = discount * greening;
            double total = greening - disPrice;

            Console.WriteLine($"The final price is: {total} lv.");
            Console.WriteLine($"The discount is: {disPrice} lv.");
        }
    }
}
