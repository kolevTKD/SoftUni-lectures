using System;

namespace _04.Transport
{
    class TransportPrice
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string dayNight = Console.ReadLine();
            string day = "day";
            string night = "night";
            double taxiTax = 0.7;
            double taxiPerKilometer = 0;
            double busTax = 0.09;
            double trainTax = 0.06;
            double totalTax = 0;
            bool taxi = kilometers < 20;
            bool bus = kilometers >= 20 && kilometers < 100;
            bool train = kilometers >= 100;

            if (dayNight == day)
            {
                taxiPerKilometer = 0.79;
            }
            else if (dayNight == night)
            {
                taxiPerKilometer = 0.9;
            }
            if (taxi)
            {
                totalTax = taxiTax + (kilometers * taxiPerKilometer);
            }
            else if (bus)
            {
                totalTax = kilometers * busTax;
            }
            else if (train)
            {
                totalTax = kilometers * trainTax;
            }
            Console.WriteLine($"{totalTax:f2}");
        }
    }
}
