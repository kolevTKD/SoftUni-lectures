using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !(value.Length >= 1 && value.Length <= 15))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_PIZZA_NAME_LENGTH);
                }

                this.name = value;
            }
        }

        public Dough Dough { get; private set; }

        public List<Topping> Toppings { get; private set; }


        public double Calories => Dough.Calories + Toppings.Sum(t => t.Calories);

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count > 10)
            {
                throw new ArgumentException(ExceptionMessages.INVALID_TOPPINGS_COUNT);
            }

            Toppings.Add(topping);
        }

        public override string ToString() => $"{Name} - {Calories:F2} Calories.";
    }
}
