namespace Vehicles.Models
{
    using Contracts;
    using Exceptions;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionLKm, double fuelModifier)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionLKm = fuelConsumptionLKm + fuelModifier;
        }

        public double FuelQuantity { get; private set; }
        
        public double FuelConsumptionLKm { get; private set; }

        public string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * FuelConsumptionLKm;

            if (FuelQuantity < fuelNeeded)
            {
                throw new VehicleNeedsRefuelingException(string.Format(ExceptionMessages.NEEDS_REFUELING, GetType().Name.ToString()));
            }

            FuelQuantity -= fuelNeeded;

            return $"{GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double litersFuel) => FuelQuantity += litersFuel;

        public override string ToString() => $"{GetType().Name}: {FuelQuantity:F2}";
    }
}
