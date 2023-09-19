namespace VehiclesExtension.Models
{
    using Contracts;

    using Exceptions;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumptionLKm, double tankCapacity, double fuelModifier)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionLKm = fuelConsumptionLKm + fuelModifier;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                fuelQuantity = CheckFuelQuantity(value);
            }
        }
        public double FuelConsumptionLKm { get; protected set; }
        public double TankCapacity { get; protected set; }

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

        public virtual void Refuel(double litersFuel)
        {
            double fuelAmount = FuelQuantity + litersFuel;

            if (fuelAmount > TankCapacity)
            {
                throw new InsufficientFuelAmountException(string.Format(ExceptionMessages.INSUFFICIENT_FUEL_AMOUNT, litersFuel));
            }
            else if (litersFuel <= 0)
            {
                throw new FuelMustBePositiveException();
            }

            FuelQuantity += litersFuel;
        }

        public override string ToString() => $"{GetType().Name}: {FuelQuantity:F2}";

        private double CheckFuelQuantity(double amount)
        {
            if (amount > TankCapacity)
            {
                amount = 0;
            }

            return amount;
        }
    }
}
