namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exceptions;

    public abstract class Animal : IAnimal
    {
        private Animal()
        {
            FoodEaten = 0;
        }
        protected Animal(string name, double weight)
            : this()
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract double WeightMultiplier { get; }
        public abstract IReadOnlyCollection<Type> Edibles { get; }

        public abstract string ProduceSound();
        public void Eat(IFood food)
        {
            if (!Edibles.Any(ft => food.GetType().Name == ft.Name))
            {
                throw new InvalidFoodTypeException(string.Format(ExceptionMessages.INVALID_FOOD_TYPE, GetType().Name, food.GetType().Name));
            }

            Weight += food.Quantity * WeightMultiplier;
            FoodEaten += food.Quantity;
        }
        public override string ToString() => $"{GetType().Name} [{Name}, ";
    }
}
