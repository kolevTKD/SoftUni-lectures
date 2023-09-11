namespace _04.PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const double DEFAULT_CALORIES_PER_GRAM = 2.0;

        private readonly Dictionary<string, double> flourTypeModifiers = new Dictionary<string, double>()
        {
            {"white", 1.5},
            {"wholegrain", 1.0 }
        };
        private readonly Dictionary<string, double> bakingTechniqueModifiers = new Dictionary<string, double>()
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!flourTypeModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_TYPE_OF_DOUGH_OR_BAKING_TECHNIQUE);
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniqueModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_TYPE_OF_DOUGH_OR_BAKING_TECHNIQUE);
                }

                bakingTechnique = value;
            }
        }

        public double Grams
        {
            get => grams;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_DOUGH_WEIGHT_RANGE);
                }

                grams = value;
            }
        }

        public double Calories() => DEFAULT_CALORIES_PER_GRAM * Grams * flourTypeModifiers[FlourType.ToLower()] * bakingTechniqueModifiers[BakingTechnique.ToLower()];
        public override string ToString() => $"{Calories():F2}";
    }
}
