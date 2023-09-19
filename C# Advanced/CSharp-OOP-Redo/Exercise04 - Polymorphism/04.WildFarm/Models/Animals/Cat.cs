namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Cat : Feline
    {
        private const double WEIGHT_MULTIPLIER = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;
        public override IReadOnlyCollection<Type> Edibles => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound() => "Meow";
    }
}
