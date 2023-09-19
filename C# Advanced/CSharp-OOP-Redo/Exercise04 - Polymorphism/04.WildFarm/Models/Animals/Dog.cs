namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Dog : Mammal
    {
        private const double WEIGHT_MULTIPLIER = 0.40;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;
        public override IReadOnlyCollection<Type> Edibles => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound() => "Woof!";
        public override string ToString() => $"{base.ToString()}{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
