namespace Vehicles.Factories
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

        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumptionLKm)
        {
            IVehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumptionLKm);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumptionLKm);
            }
            else
            {
                throw new VehicleNotSupportedException();
            }

            return vehicle;
        }
    }
}
