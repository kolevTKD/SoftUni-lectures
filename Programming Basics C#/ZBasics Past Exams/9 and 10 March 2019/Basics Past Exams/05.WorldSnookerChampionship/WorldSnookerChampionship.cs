using System;

namespace _05.WorldSnookerChampionship
{
    class WorldSnookerChampionship
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string ticket = Console.ReadLine();
            int ticketsNum = int.Parse(Console.ReadLine());
            char trophyPhoto = char.Parse(Console.ReadLine());
            double pricePerTicket = 0;
            

            switch (stage)
            {
                case "Quarter final":

                    switch (ticket)
                    {
                        case "Standard":
                            pricePerTicket = 55.5;
                            break;
                        case "Premium":
                            pricePerTicket = 105.2;
                            break;
                        case "VIP":
                            pricePerTicket = 118.9;
                            break;
                    }
                    break;

                case "Semi final":

                    switch (ticket)
                    {
                        case "Standard":
                            pricePerTicket = 75.88;
                            break;
                        case "Premium":
                            pricePerTicket = 125.22;
                            break;
                        case "VIP":
                            pricePerTicket = 300.4;
                            break;
                    }
                    break;

                case "Final":

                    switch (ticket)
                    {
                        case "Standard":
                            pricePerTicket = 110.1;
                            break;
                        case "Premium":
                            pricePerTicket = 160.66;
                            break;
                        case "VIP":
                            pricePerTicket = 400;
                            break;
                    }
                    break;
            }

            double totalSum = pricePerTicket * ticketsNum;
            bool free = false;

            if (totalSum > 4000)
            {
                free = true;
                totalSum *= 0.75;
            }

            else if (totalSum > 2500)
            {
                totalSum *= 0.9;
            }

            if (totalSum <= 4000 && trophyPhoto == 'Y' && !free)
            {
                double totalForPhotos = ticketsNum * 40;
                totalSum += totalForPhotos;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
