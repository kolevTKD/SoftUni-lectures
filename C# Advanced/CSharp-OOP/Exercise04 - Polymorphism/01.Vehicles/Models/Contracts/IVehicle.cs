namespace VehiclesExtension.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        string Drive(double kilometers);
        void Refuel(double liters);
    }
}
