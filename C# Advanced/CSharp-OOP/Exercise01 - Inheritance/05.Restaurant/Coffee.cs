using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILlILITERS = 50;
        private const decimal COFFEE_PRICE = 3.5M;
        public Coffee(string name, double caffeine)
            : base(name, COFFEE_PRICE, COFFEE_MILlILITERS)
        {
            CoffeeMilliliters = COFFEE_MILlILITERS;
            CoffeePrice = COFFEE_PRICE;
            Caffeine = caffeine;
        }

        public double CoffeeMilliliters { get; set; }
        public decimal CoffeePrice { get; set; }
        public double Caffeine { get; set; }
    }
}
