using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carsNum = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int currCar = 0; currCar < carsNum; currCar++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeigth = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);

                Engine engine = new Engine()
                {
                    Speed = engineSpeed,
                    Power = enginePower
                };

                Cargo cargo = new Cargo()
                {
                    Weigth = cargoWeigth,
                    Type = cargoType
                };

                Tire[] tires = new Tire[]
                {
                    new Tire(){Age = tire1Age, Pressure = tire1Pressure},
                    new Tire(){Age = tire2Age, Pressure = tire2Pressure},
                    new Tire(){Age = tire3Age, Pressure = tire3Pressure},
                    new Tire(){Age = tire4Age, Pressure = tire4Pressure}
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string cargoFilter = Console.ReadLine();

            string[] filteredCars = cargoFilter == "fragile" ? cars
                    .Where(c => c.Cargo.Type == cargoFilter && c.Tires.Any(t => t.Pressure < 1))
                    .Select(c => c.Model)
                    .ToArray()
                    :
                    filteredCars = cars
                    .Where(c => c.Cargo.Type == cargoFilter && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, filteredCars));
        }
    }
}
