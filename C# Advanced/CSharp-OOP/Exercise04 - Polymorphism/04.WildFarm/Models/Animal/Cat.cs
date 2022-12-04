namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Cat : Feline
    {
        private const double CAT_WEIGHT_MULTIPLIER = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => CAT_WEIGHT_MULTIPLIER;

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() { typeof(Vegetable), typeof(Meat)};

        public override string ProduceSound() => "Meow";
    }
}
