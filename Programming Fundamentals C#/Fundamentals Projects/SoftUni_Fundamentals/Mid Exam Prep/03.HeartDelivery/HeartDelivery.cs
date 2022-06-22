using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class HeartDelivery
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string end = "Love!";
            int cupidIndex = 0;
            int housesFailed = neighborhood.Count;

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commands[0];

                if (command == end)
                {
                    break;
                }

                int jumpLength = int.Parse(commands[1]);
                cupidIndex += jumpLength;

                if (cupidIndex >= neighborhood.Count)
                {
                    cupidIndex = 0;
                }
                
                neighborhood[cupidIndex] -= 2;

                if (neighborhood[cupidIndex] <= 0) //
                {
                    if (neighborhood[cupidIndex] < 0) //
                    {
                        neighborhood[cupidIndex] = 0;
                        Console.WriteLine($"Place {cupidIndex} already had Valentine's day.");
                        continue;
                    }

                    housesFailed--;
                    Console.WriteLine($"Place {cupidIndex} has Valentine's day.");
                }
            }

            Console.WriteLine($"Cupid's last position was {cupidIndex}.");

            if (neighborhood.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");

                return;
            }

            Console.WriteLine($"Cupid has failed {housesFailed} places.");
        }
    }
}
