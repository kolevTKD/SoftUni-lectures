using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class TruckTour
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<long[]> pumps = new Queue<long[]>();

            for (int i = 0; i < petrolPumps; i++)
            {
                long[] currentPump = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                pumps.Enqueue(currentPump);
            }

            for (int index = 0; index < pumps.Count; index++)
            {
                long tankCapacity = 0;
                long[] startingPump = pumps.Peek();
                long fuel = startingPump[0];
                long distance = startingPump[1];

                if (fuel < distance)
                {
                    pumps.Dequeue();
                    pumps.Enqueue(startingPump);
                    continue;
                }

                pumps.Dequeue();
                tankCapacity += fuel;
                tankCapacity -= distance;
                Queue<long[]> subQueue = new Queue<long[]>(pumps);

                for (int pump = 0; pump < pumps.Count; pump++)
                {
                    long[] currentPump = pumps.Peek();
                    long currentFuel = currentPump[0];
                    long currentDistance = currentPump[1];

                    if (currentPump == startingPump)
                    {
                        int bestRouteIndex = index;
                        Console.WriteLine(bestRouteIndex);

                        return;
                    }

                    pumps.Enqueue(startingPump);

                    if (tankCapacity + currentFuel < currentDistance)
                    {
                        pumps = subQueue;
                        pumps.Enqueue(startingPump);
                        break;
                    }

                    tankCapacity += currentFuel;
                    tankCapacity -= currentDistance;
                    pumps.Dequeue();
                    pumps.Enqueue(currentPump);
                }
            }
        }
    }
}
