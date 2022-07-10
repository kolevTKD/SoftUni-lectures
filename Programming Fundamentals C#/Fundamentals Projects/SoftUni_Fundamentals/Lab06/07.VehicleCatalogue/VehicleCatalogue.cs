using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            string[] vehicle = Console.ReadLine().Split('/').ToArray();
            string end = "end";
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (vehicle[0] != end)
            {
                string type = vehicle[0];
                string brand = vehicle[1];
                string model = vehicle[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(vehicle[3]);
                    Car car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;
                    cars.Add(car);
                }

                else if (type == "Truck")
                {
                    double weight = double.Parse(vehicle[3]);
                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;
                    trucks.Add(truck);
                }
                vehicle = Console.ReadLine().Split('/').ToArray();
            }


            if (cars.Count != 0)
            {
                Console.WriteLine("Cars:");
                cars = cars.OrderBy(brand => brand.Brand).ToList();

                foreach (Car car in cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                trucks = trucks.OrderBy(brand => brand.Brand).ToList();

                foreach (Truck truck in trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Catalog
    {
        public List<string> Cars { get; set; }
        public List<string> Trucks { get; set; }
    }
}
