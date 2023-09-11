namespace _04.PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Pizza
    {
        private string name;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            Toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_PIZZA_NAME_LENGTH);
                }

                name = value;
            }
        }

        public Dough Dough { get; private set; }
        public List<Topping> Toppings { get; private set; }

        public double TotalCalories() => Dough.Calories() + Toppings.Sum(t => t.Calories());
        public void AddTopping(Topping topping)
        {
            if (Toppings.Count > 10)
            {
                throw new ArgumentException(ExceptionMessages.INVALID_TOPPINGS_COUNT);
            }

            Toppings.Add(topping);
        }

        public override string ToString() => $"{Name} - {TotalCalories():F2} Calories.";
    }
}
