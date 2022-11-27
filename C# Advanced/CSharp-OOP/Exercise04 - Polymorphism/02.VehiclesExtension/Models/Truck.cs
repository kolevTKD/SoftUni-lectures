using VehiclesExtension.Exceptions;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double REFUEL_MODIFIER = 0.95;
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + FUEL_CONSUMPTION_INCREMENT, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            if (this.FuelQuantity + liters * REFUEL_MODIFIER > this.TankCapacity)
            {
                throw new ImmersiveFuelAmountException(string.Format(ExceptionMessages.IMMERSIVE_FUEL_AMOUNT, liters));
            }

            else if (liters <= 0)
            {
                throw new InvalidFuelQuantityException();
            }

            else
            {
                base.Refuel(liters * REFUEL_MODIFIER);
            }
        }
    }
}
