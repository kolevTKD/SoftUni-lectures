using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            string[] currVehicle = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string end = "End";
            List<Vehicle> vehicles = new List<Vehicle>();

            while (currVehicle[0] != end)
            {
                string type = currVehicle[0];
                string model = currVehicle[1];
                string color = currVehicle[2];
                double horsePower = double.Parse(currVehicle[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsePower);
                vehicles.Add(vehicle);

                currVehicle = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            string vehicleInfo = Console.ReadLine();
            string closeCatalogue = "Close the Catalogue";

            while (vehicleInfo != closeCatalogue)
            {
                if (vehicles.Any(model => model.Model == vehicleInfo))
                {
                    Vehicle currentVehicle = vehicles.FirstOrDefault(model => model.Model == vehicleInfo);
                    string currVehicleType = currentVehicle.Type;
                    Console.WriteLine($"Type: {char.ToUpper(currVehicleType[0])}{currVehicleType.Substring(1)}");
                    Console.WriteLine($"Model: {currentVehicle.Model}");
                    Console.WriteLine($"Color: {currentVehicle.Color}");
                    Console.WriteLine($"Horsepower: {currentVehicle.HorsePower}");
                }

                vehicleInfo = Console.ReadLine();
            }

            var carsList = vehicles.Where(type => type.Type == "car").ToList();
            var trucksList = vehicles.Where(type => type.Type == "truck").ToList();

            double carsHp = carsList.Count > 0 ? carsList.Average(hp => hp.HorsePower) : 0.00;
            double trucksHp = trucksList.Count > 0 ? trucksList.Average(hp => hp.HorsePower) : 0.00;
            
            Console.WriteLine($"Cars have average horsepower of: {carsHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksHp:f2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, double horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }
}
