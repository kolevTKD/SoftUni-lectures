namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, FUEL_CONSUMPTION_INCREMENT)
        {
        }

        public override void Refuel(double liters) => base.Refuel(liters * 0.95);
    }
}
