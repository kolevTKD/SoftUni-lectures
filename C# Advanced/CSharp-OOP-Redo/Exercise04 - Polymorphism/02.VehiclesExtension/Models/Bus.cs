namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_MODIFIER = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionLKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLKm, tankCapacity, FUEL_MODIFIER)
        {
        }

        public string DriveEmpty(double kilometers)
        {
            FuelConsumptionLKm -= FUEL_MODIFIER;
            string result = Drive(kilometers);
            FuelConsumptionLKm += FUEL_MODIFIER;

            return result;
        }
    }
}
