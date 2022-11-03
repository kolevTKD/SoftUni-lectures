using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories.Models
{
    public class Topping
    {
        private string type;
        private double weight;

        private readonly Dictionary<string, double> topings = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!topings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TYPE_OF_TOPPING, value));
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TOPPING_WEIGHT, Type));
                }

                this.weight = value;
            }
        }

        public double Calories => 2 * Weight * topings[Type.ToLower()];

        public override string ToString() => $"{Calories:F2}";
    }
}
