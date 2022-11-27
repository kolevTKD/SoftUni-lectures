namespace VehiclesExtension.Models
{
    using VehiclesExtension.Exceptions;
    using VehiclesExtension.Models.Contracts;
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            double fuel = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuel;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; protected set; }

        public virtual string Drive(double kilometers)
        {
            double neededFuel = this.FuelConsumption * kilometers;

            if (neededFuel > this.FuelQuantity)
            {
                throw new VehicleNeedsRefuelingException(string.Format(ExceptionMessages.INSUFFICIENT_FUEL, this.GetType().Name.ToString()));
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ImmersiveFuelAmountException(string.Format(ExceptionMessages.IMMERSIVE_FUEL_AMOUNT, liters));
            }

            else if (liters <= 0)
            {
                throw new InvalidFuelQuantityException();
            }

             this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
