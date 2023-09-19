namespace VehiclesExtension.Models
{
    using VehiclesExtension.Exceptions;
    public class Truck : Vehicle
    {
        private const double REFUEL_MODIFIER = 0.95;
        private const double FUEL_MODIFIER = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionLKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLKm, tankCapacity, FUEL_MODIFIER)
        {
        }

        public override void Refuel(double litersFuel)
        {
            double fuelAmount = FuelQuantity + litersFuel * REFUEL_MODIFIER;

            if (fuelAmount > TankCapacity)
            {
                throw new InsufficientFuelAmountException(string.Format(ExceptionMessages.INSUFFICIENT_FUEL_AMOUNT, litersFuel));
            }
            else if (litersFuel <= 0)
            {
                throw new FuelMustBePositiveException();
            }

            base.Refuel(litersFuel * REFUEL_MODIFIER);
        }
    }
}
