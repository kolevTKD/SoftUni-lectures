﻿namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Mouse : Mammal
    {
        private const double MOUSE_WEIGHT_MULTIPLIER = 0.1;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => MOUSE_WEIGHT_MULTIPLIER;

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound() => "Squeak";

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
