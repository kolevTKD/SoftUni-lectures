namespace VehiclesExtension.Models
{
    using Exceptions;
    public class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + FUEL_CONSUMPTION_INCREMENT, tankCapacity)
        {
        }

        public string DriveEmpty(double kilometers)
        {
            base.FuelConsumption -= FUEL_CONSUMPTION_INCREMENT;
            string result = base.Drive(kilometers);
            base.FuelConsumption += FUEL_CONSUMPTION_INCREMENT;

            return result;
        }
    }
}
