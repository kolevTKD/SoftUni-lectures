using System;

namespace _02.ReportSystem
{
    class ReportSystem
    {
        static void Main(string[] args)
        {
            int sumNeeded = int.Parse(Console.ReadLine());
            double totalSum = 0;
            double cashPayment = 0;
            double cardPayment = 0;
            string input = null;
            string end = "End";
            int paymentCount = 0;
            int cashCount = 0;
            int cardCount = 0;

            while (input != end)
            {
                input = Console.ReadLine();

                if (input == end)
                {
                    break;
                }

                double itemPrice = double.Parse(input);
                paymentCount++;

                if (paymentCount % 2 == 1)
                {
                    if (itemPrice > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                        continue;
                    }

                    else
                    {
                        cashPayment += itemPrice;
                        cashCount++;
                        Console.WriteLine("Product sold!");
                    }

                }

                if (paymentCount % 2 == 0)
                {
                    if (itemPrice < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                        continue;
                    }

                    else
                    {
                        cardPayment += itemPrice;
                        cardCount++;
                        Console.WriteLine("Product sold!");
                    }

                }

                totalSum += itemPrice;

                if (totalSum >= sumNeeded)
                {
                    break;
                }
            }

            double avgCash = cashPayment / cashCount;
            double avgCard = cardPayment / cardCount;

            if (totalSum < sumNeeded)
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }

            else
            {
                Console.WriteLine($"Average CS: {avgCash:f2}");
                Console.WriteLine($"Average CC: {avgCard:f2}");
            }
        }
    }
}
