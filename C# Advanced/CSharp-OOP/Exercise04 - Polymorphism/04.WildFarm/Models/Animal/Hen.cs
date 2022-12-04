namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Hen : Bird
    {
        private const double HEN_WEIGHT_MULTIPLIER = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => HEN_WEIGHT_MULTIPLIER;

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };

        public override string ProduceSound() => "Cluck";
    }
}
