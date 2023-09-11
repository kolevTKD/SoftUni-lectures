namespace _04.PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    public class Topping
    {
        private const double DEFAULT_CALORIES_PER_GRAM = 2.0;

        private readonly Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CANNOT_PLACE_TOPPING_TYPE_ON_PIZZA, value));
                }
                
                type = value;
            }
        }
        public double Grams
        {
            get => grams;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TOPPING_WEIGHT_RANGE, Type));
                }

                grams = value;
            }
        }

        public double Calories() => DEFAULT_CALORIES_PER_GRAM * Grams * toppings[Type.ToLower()];
        public override string ToString() => $"{Calories():F2}";
    }
}
