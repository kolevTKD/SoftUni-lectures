namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using WildFarm.Exceptions;

    public abstract class Animal : IAnimal
    {
        private Animal()
        {
            this.FoodEaten = 0;
        }
        protected Animal(string name, double weight)
            : this()
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }
        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }
        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!this.PreferredFoods.Any(ft => food.GetType().Name == ft.Name))
            {
                throw new FoodNotEatenException(string.Format(ExceptionMessages.FOOD_NOT_EATEN_EXCEPTION_MESSAGE, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
