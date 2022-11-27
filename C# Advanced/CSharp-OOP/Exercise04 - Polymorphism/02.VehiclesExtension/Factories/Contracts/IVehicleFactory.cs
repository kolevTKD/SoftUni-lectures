namespace VehiclesExtension.Factories.Contracts
{
    using Models.Contracts;
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
