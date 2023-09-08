namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double RACE_MOTORCYCLE_DEFAULT_FUEL_CONSUMPTION = 8.0;
        public RaceMotorcycle (int horsePower, double fuel)
            : base (horsePower, fuel)
        {
        }

        public override double FuelConsumption => RACE_MOTORCYCLE_DEFAULT_FUEL_CONSUMPTION;
    }
}
