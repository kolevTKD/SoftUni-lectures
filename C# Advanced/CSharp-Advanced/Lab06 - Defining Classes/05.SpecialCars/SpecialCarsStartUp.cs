using CarManufacturer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SpecialCars
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                double[] tiresInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => double.Parse(n)).ToArray();

                tires.Add(new Tire[4]
                {
                    new Tire((int)tiresInfo[0], tiresInfo[1]),
                    new Tire((int)tiresInfo[2], tiresInfo[3]),
                    new Tire((int)tiresInfo[4], tiresInfo[5]),
                    new Tire((int)tiresInfo[6], tiresInfo[7])
                });

                input = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                double[] engineInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => double.Parse(n)).ToArray();

                int horsePower = (int)engineInfo[0];
                double cubicCapacity = engineInfo[1];

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                input = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();

            input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] carInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);

                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    double tiresPressure = 0;

                    foreach (Tire tire in car.Tires)
                    {
                        tiresPressure += tire.Pressure;
                    }

                    if (tiresPressure >= 9 && tiresPressure <= 10)
                    {
                        car.Drive(20);
                        Console.WriteLine(car.WhoAmI());
                    }
                }
            }
        }
    }
}
