using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    internal class TrafficJam
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());
            string car = Console.ReadLine();
            Queue<string> carsAtLight = new Queue<string>();
            int passedCount = 0;

            while (car != "end")
            {
                if (car == "green")
                {
                    if (carsAtLight.Count < carsToPass)
                    {
                        carsToPass = carsAtLight.Count;
                    }

                    for (int carNum = 0; carNum < carsToPass; carNum++)
                    {
                        Console.WriteLine($"{carsAtLight.Dequeue()} passed!");
                        passedCount++;
                    }

                    car = Console.ReadLine();
                    continue;
                }

                carsAtLight.Enqueue(car);
                car = Console.ReadLine();
            }

            Console.WriteLine($"{passedCount} cars passed the crossroads.");
        }
    }
}
