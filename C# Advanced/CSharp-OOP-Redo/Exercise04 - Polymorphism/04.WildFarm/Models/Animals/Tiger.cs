namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Tiger : Feline
    {
        private const double WEIGHT_MULTIPLIER = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;
        public override IReadOnlyCollection<Type> Edibles => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound() => "ROAR!!!";
    }
}
