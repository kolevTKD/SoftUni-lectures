namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_MODIFIER = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionLKm)
            : base(fuelQuantity, fuelConsumptionLKm, FUEL_MODIFIER)
        {
        }

        public override void Refuel(double litersFuel) => base.Refuel(litersFuel * 0.95);
    }
}
