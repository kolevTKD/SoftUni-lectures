using System;
using System.Collections.Generic;

namespace _06._3.SpeedRacing
{
    internal class SpeedRacing
    {
        static void Main(string[] args)
        {
            List<Car> carList = GetInfo();
            Print(carList);
        }

        static List<Car> GetInfo()
        {
            int cars = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for (int i = 0; i < cars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelCap = double.Parse(carInfo[1]);
                double fuelPerKm = double.Parse(carInfo[2]);
                int distance = 0;

                Car car = new Car(model, fuelCap, fuelPerKm, distance);
                carList.Add(car);
            }

            while (true)
            {
                string[] carDrive = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (carDrive[0] == "End")
                {
                    break;
                }

                string carModel = carDrive[1];
                int amountOfKm = int.Parse(carDrive[2]);

                Car currentCar = carList.Find(x => x.Model == carModel);
                currentCar.Drive(amountOfKm);

            }

            return carList;
        }

        static void Print(List<Car> carList)
        {
            foreach (Car car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelCap:f2} {car.Distance}");
            }
        }

    }

    class Car
    {
        public Car(string model, double fuelCap, double fuelPerKm, int distance)
        {
            Model = model;
            FuelCap = fuelCap;
            FuelPerKm = fuelPerKm;
            Distance = distance;
        }

        public string Model { get; set; }
        public double FuelCap { get; set; }
        public double FuelPerKm { get; set; }
        public int Distance { get; set; }

        public Car Drive(int amountOfKm)
        {
            double usedFuel = FuelPerKm * amountOfKm;

            if (FuelCap - usedFuel >= 0)
            {
                Distance += amountOfKm;
                FuelCap -= usedFuel;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            return this;
        }
    }
}
