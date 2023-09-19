namespace Vehicles.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumptionLKm { get; }

        string Drive(double kilometers);
        void Refuel(double litersFuel);
    }
}
