namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;

    using Food;
    public class Owl : Bird
    {
        private const double OWL_WEIGHT_MULTIPLIER = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => OWL_WEIGHT_MULTIPLIER;

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound() => "Hoot Hoot";
    }
}
