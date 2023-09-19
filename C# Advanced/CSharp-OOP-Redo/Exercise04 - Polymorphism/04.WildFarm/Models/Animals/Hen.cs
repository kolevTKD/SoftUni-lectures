namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;
    public class Hen : Bird
    {
        private const double WEIGHT_MULTIPLIER = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;
        public override IReadOnlyCollection<Type> Edibles => new HashSet<Type>() { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };

        public override string ProduceSound() => "Cluck";
    }
}
