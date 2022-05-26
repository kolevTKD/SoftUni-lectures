using System;

namespace _01.MatchTickets
{
    class MatchTickets
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int peopleNum = int.Parse(Console.ReadLine());
            string vip = "VIP";
            string normal = "Normal";
            double ticketPrice = 0;
            double transport = 0;
            double moneySpent = 0;
            bool oneTo4 = peopleNum >= 1 && peopleNum <= 4;
            bool fiveTo9 = peopleNum >= 5 && peopleNum <= 9;
            bool tenTo24 = peopleNum >= 10 && peopleNum <= 24;
            bool tfTo49 = peopleNum >= 25 && peopleNum <= 49;
            bool plus50 = peopleNum >= 50;

            if (oneTo4)
            {
                transport = budget * 0.75;
            }

            else if (fiveTo9)
            {
                transport = budget * 0.6;
            }

            else if (tenTo24)
            {
                transport = budget * 0.5;
            }

            else if (tfTo49)
            {
                transport = budget * 0.4;
            }

            else if (plus50)
            {
                transport = budget * 0.25;
            }

            moneySpent += transport;

            if (category == vip)
            {
                ticketPrice = 499.99;
            }

            else if (category == normal)
            {
                ticketPrice = 249.99;
            }

            double totalForTickets = peopleNum * ticketPrice;
            moneySpent += totalForTickets;

            if (moneySpent <= budget)
            {
                double moneyLeft = budget - moneySpent;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }

            else
            {
                double moneyNeeded = moneySpent - budget;
                Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva.");
            }
        }
    }
}
