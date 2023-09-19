namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_MODIFIER = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionLKm)
            : base(fuelQuantity, fuelConsumptionLKm, FUEL_MODIFIER)
        {
        }
    }
}
