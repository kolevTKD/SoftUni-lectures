using System;
using System.Collections.Generic;

namespace _06._3.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = GetInfo();
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

            return carList;
        }

        static List<Car> Drive(List<Car> carList)
        {
            
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
    }
}
