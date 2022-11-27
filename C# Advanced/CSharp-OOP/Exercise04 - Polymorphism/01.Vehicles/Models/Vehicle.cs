namespace VehiclesExtension.Models
{
    using VehiclesExtension.Exceptions;
    using VehiclesExtension.Models.Contracts;
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double fuelConsumptionIncrement)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + fuelConsumptionIncrement;
        }
        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double kilometers)
        {
            double neededFuel = this.FuelConsumption * kilometers;

            if (neededFuel > this.FuelQuantity)
            {
                throw new VehicleNeedsRefuelingException(string.Format(ExceptionMessages.INSUFFICIENT_FUEL, this.GetType().Name.ToString()));
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double liters) => this.FuelQuantity += liters;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
