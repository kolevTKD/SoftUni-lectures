﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double FISH_GRAMS = 22;
        public Fish(string name, decimal price)
            : base(name, price, FISH_GRAMS)
        {
            Grams = FISH_GRAMS;
        }

        public override double Grams { get; set; }
    }
}
