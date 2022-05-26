using System;

namespace _06.CinemaTickets
{
    class CinemaTickets
    {
        static void Main(string[] args)
        {
            string input = null;
            string finish = "Finish";
            string end = "End";
            string student = "student";
            string standard = "standard";
            string kid = "kid";
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;

            while (input != finish)
            {
                input = Console.ReadLine();
                if (input == finish)
                {
                    break;
                }
                int freeSeats = int.Parse(Console.ReadLine());

                int ticketsNum = 0;

                while (input != end)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == end)
                    {
                        break;
                    }
                    if (ticketType == student)
                    {
                        studentTickets++;
                    }
                    else if (ticketType == standard)
                    {
                        standardTickets++;
                    }
                    else if (ticketType == kid)
                    {
                        kidTickets++;
                    }

                    ticketsNum++;

                    if (ticketsNum == freeSeats)
                    {
                        break;
                    }
                }

                double totalSeatsTakenP = (double)ticketsNum / (double)freeSeats * 100;
                Console.WriteLine($"{input} - {totalSeatsTakenP:f2}% full.");
            }

            double totalTicketsNum = studentTickets + standardTickets + kidTickets;
            double studentTicketsP = studentTickets / totalTicketsNum * 100;
            double standardTicketsP = standardTickets / totalTicketsNum * 100;
            double kidTicketsP = kidTickets / totalTicketsNum * 100;

            Console.WriteLine($"Total tickets: {totalTicketsNum}");
            Console.WriteLine($"{studentTicketsP:f2}% student tickets.");
            Console.WriteLine($"{standardTicketsP:f2}% standard tickets.");
            Console.WriteLine($"{kidTicketsP:f2}% kids tickets.");
        }
    }
}
