namespace VehiclesExtension.Factories
{
    using Contracts;
    using Exceptions;
    using Models;
    using Models.Contracts;

    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {
        }

        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumptionLKm, double tankCapacity)
        {
            IVehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumptionLKm, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumptionLKm, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumptionLKm, tankCapacity);
            }
            else
            {
                throw new VehicleNotSupportedException();
            }

            return vehicle;
        }
    }
}
