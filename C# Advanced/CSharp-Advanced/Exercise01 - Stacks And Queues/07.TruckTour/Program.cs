using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            int tankCapacity = 0;
            int pumpIndex = 0;

            for (int i = 0; i < petrolPumps; i++)
            {
                int[] currentPump = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                pumps.Enqueue(currentPump);
            }

            while (true)
            {
                int[] startingPump = pumps.Dequeue();
                int fuel = startingPump[0];
                int distance = startingPump[1];

                if (fuel < distance)
                {
                    pumps.Enqueue(startingPump);
                    pumpIndex++;
                    continue;
                }

                tankCapacity += fuel;
                tankCapacity -= distance;
                int[] currentPump = pumps.Dequeue();

                while (tankCapacity >= currentPump[1])
                {
                    if (tankCapacity + currentPump[0] < currentPump[1])
                    {
                        pumps.Enqueue(currentPump);
                        pumps.Enqueue(startingPump);
                        pumpIndex++;
                        tankCapacity = 0;
                        break;
                    }
                }
            }
        }
    }
}
