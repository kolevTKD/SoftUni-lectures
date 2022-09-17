using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int greenLight = greenDuration + freeWindow;
            Queue<string> cars = new Queue<string>();

            while (true)
            {
                string car = Console.ReadLine();

                if (car == "END")
                {
                    break;
                }

                else if (car != "green")
                {
                    cars.Enqueue(car);
                    continue;
                }

                foreach (string vehicle in cars)
                {
                    string currentCar = vehicle;

                    for (int secs = 0; secs < greenLight; secs++)
                    {
                        if (cu)
                        {

                        }
                    }
                }

            }
        }
    }
}
