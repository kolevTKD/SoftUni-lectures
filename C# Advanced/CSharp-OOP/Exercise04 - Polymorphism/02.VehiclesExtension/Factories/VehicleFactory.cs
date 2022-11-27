namespace VehiclesExtension.Factories
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
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            IVehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else
            {
                throw new InvalidVehicleTypeException();
            }

            return vehicle;
        }
    }
}
