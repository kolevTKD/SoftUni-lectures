namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Mouse : Mammal
    {
        private const double WEIGHT_MULTIPLIER = 0.10;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override IReadOnlyCollection<Type> Edibles => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };
        public override string ProduceSound() => "Squeak";
        public override string ToString() => $"{base.ToString()}{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
