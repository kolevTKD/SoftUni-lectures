using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double SPORTCAR_DEFAULT_FUEL_CONSUMPTION = 10;
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => SPORTCAR_DEFAULT_FUEL_CONSUMPTION;
    }
}
