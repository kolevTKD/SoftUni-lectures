using System;

namespace _05.ChristmasGifts
{
    class ChristmasGifts
    {
        static void Main(string[] args)
        {
            string end = "Christmas";
            string input = null;
            int kidsCounter = 0;
            int adultCounter = 0;
            double presentPrice = 0;
            double totalForKids = 0;
            double totalForAdults = 0;

            while (input != end)
            {
                input = Console.ReadLine();

                if (input == end)
                {
                    break;
                }

                int age = int.Parse(input);

                if (age <= 16)
                {
                    kidsCounter++;
                    presentPrice = 5;
                    totalForKids += presentPrice;
                }

                else if (age > 16)
                {
                    adultCounter++;
                    presentPrice = 15;
                    totalForAdults += presentPrice;
                }
            }

            Console.WriteLine($"Number of adults: {adultCounter}");
            Console.WriteLine($"Number of kids: {kidsCounter}");
            Console.WriteLine($"Money for toys: {totalForKids}");
            Console.WriteLine($"Money for sweaters: {totalForAdults}");
        }
    }
}
