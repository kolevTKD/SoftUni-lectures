namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Owl : Bird
    {
        private const double WEIGHT_MULTIPLIER = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;
        public override IReadOnlyCollection<Type> Edibles => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound() => "Hoot Hoot";
    }
}
