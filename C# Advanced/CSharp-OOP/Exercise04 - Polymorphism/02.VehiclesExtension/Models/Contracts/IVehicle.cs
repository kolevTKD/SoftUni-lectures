namespace VehiclesExtension.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }

        string Drive(double kilometers);
        void Refuel(double liters);
    }
}
