namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double CAR_DEFAULT_FUEL_CONSUMPTION = 3.0;
        public Car(int horsePower, double fuel)
            : base (horsePower, fuel)
        {
        }

        public override double FuelConsumption => CAR_DEFAULT_FUEL_CONSUMPTION;
    }
}
