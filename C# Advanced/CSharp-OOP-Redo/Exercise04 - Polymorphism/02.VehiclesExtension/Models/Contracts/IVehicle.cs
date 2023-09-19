namespace VehiclesExtension.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionLKm { get; }
        double TankCapacity { get; }

        string Drive(double kilometers);
        void Refuel(double litersFuel);
    }
}
