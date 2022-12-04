namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Dog : Mammal
    {
        private const double DOG_WEIGHT_MULTIPLIER = 0.4;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => DOG_WEIGHT_MULTIPLIER;

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type>() { typeof(Meat)};

        public override string ProduceSound() => "Woof!";

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
