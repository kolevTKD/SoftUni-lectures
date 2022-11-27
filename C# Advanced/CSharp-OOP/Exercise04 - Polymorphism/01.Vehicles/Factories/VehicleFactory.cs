﻿namespace VehiclesExtension.Factories
{
    using Exceptions;
    using Factories.Contracts;
    using Models;
    using Models.Contracts;

    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {
        }
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            IVehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }

            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            else
            {
                throw new InvalidVehicleTypeException();
            }

            return vehicle;
        }
    }
}
