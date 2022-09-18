using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    internal class Crossroads
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int carsPassed = 0;
            Queue<string> cars = new Queue<string>();
            string car;

            while ((car = Console.ReadLine()) != "END")
            {
                if (car != "green")
                {
                    cars.Enqueue(car);
                    continue;
                }

                else if (car == "green" && cars.Any())
                {

                    string currentCar = cars.Dequeue();
                    Queue<char> carChars = new Queue<char>(currentCar);

                    for (int green = 0; green < greenDuration; green++)
                    {
                        if (carChars.Any())
                        {
                            carChars.Dequeue();

                            if (!carChars.Any())
                            {
                                carsPassed++;
                            }
                        }

                        else if (cars.Any())
                        {
                            currentCar = cars.Dequeue();

                            foreach (char ch in currentCar)
                            {
                                carChars.Enqueue(ch);
                            }

                            carChars.Dequeue();
                        }
                    }

                    for (int free = 0; free < freeWindow; free++)
                    {
                        if (carChars.Any())
                        {
                            carChars.Dequeue();

                            if (!carChars.Any())
                            {
                                carsPassed++;
                            }
                        }
                    }

                    if (carChars.Any())
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {carChars.Peek()}.");
                        return;
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
