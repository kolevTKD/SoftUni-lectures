namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_MODIFIER = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionLKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLKm, tankCapacity, FUEL_MODIFIER)
        {
        }
    }
}
