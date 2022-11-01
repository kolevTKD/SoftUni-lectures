using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CAKE_GRAMS = 250;
        private const double CAKE_CALORIES = 1000;
        private const decimal CAKE_PRICE = 5;
        public Cake(string name)
            : base(name, CAKE_PRICE, CAKE_GRAMS, CAKE_CALORIES)
        {
            Grams = CAKE_GRAMS;
            Calories = CAKE_CALORIES;
            CakePrice = CAKE_PRICE;
        }

        public override double Grams { get; set; }
        public override double Calories { get; set; }
        public decimal CakePrice { get; set; }
    }
}
