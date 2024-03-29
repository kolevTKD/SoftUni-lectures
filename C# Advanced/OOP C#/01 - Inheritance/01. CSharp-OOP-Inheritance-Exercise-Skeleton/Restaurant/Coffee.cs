﻿namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50.0;
        private const decimal COFFEE_PRICE = 3.50m;
        public Coffee (string name, double caffeine)
            : base (name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
        public override double Milliliters => COFFEE_MILLILITERS;
        public override decimal Price => COFFEE_PRICE;
    }
}
