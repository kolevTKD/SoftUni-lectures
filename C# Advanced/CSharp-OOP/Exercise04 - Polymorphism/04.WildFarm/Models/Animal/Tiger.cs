namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Food;

    public class Tiger : Feline
    {
        private const double TIGER_WEIGHT_MULTIPLIER = 1;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => TIGER_WEIGHT_MULTIPLIER;

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() { typeof(Meat)};

        public override string ProduceSound() => "ROAR!!!";
    }
}
