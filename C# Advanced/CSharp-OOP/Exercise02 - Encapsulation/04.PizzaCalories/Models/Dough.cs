using System;

namespace _04.PizzaCalories.Models
{
    public class Dough
    {
        private const double WHITE_FLOUR = 1.5;
        private const double WHOLEGRAIN_FLOUR = 1;
        private const double CRISPY_BAKED = 0.9;
        private const double CHEWY_BAKED = 1.1;
        private const double HOMEMADE = 1;
        private const double BASE_CALORIES = 2;

        private double flourTypeModifier;
        private double bakingTechniqueModifier;
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public double FlourTypeModifier
        {
            get
            {
                return flourTypeModifier;
            }
            private set
            {
                flourTypeModifier = value;
            }
        }

        public double BakingTechniqueModifier
        {
            get
            {
                return bakingTechniqueModifier;
            }
            private set
            {
                bakingTechniqueModifier = value;
            }
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                flourType = value;

                if (FlourType.ToLower() == "white")
                {
                    flourTypeModifier = WHITE_FLOUR;
                }

                else if (FlourType.ToLower() == "wholegrain")
                {
                    flourTypeModifier = WHOLEGRAIN_FLOUR;
                }

                else
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_TYPE_OF_DOUGH);
                }
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                bakingTechnique = value;

                if (BakingTechnique.ToLower() == "crispy")
                {
                    bakingTechniqueModifier = CRISPY_BAKED;
                }

                else if (BakingTechnique.ToLower() == "chewy")
                {
                    bakingTechniqueModifier = CHEWY_BAKED;
                }

                else if (BakingTechnique.ToLower() == "homemade")
                {
                    bakingTechniqueModifier = HOMEMADE;
                }

                else
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_TYPE_OF_DOUGH);
                }
            }
        }
        public double Grams
        {
            get
            {
                return grams;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_DOUGH_WEIGHT);
                }

                this.grams = value;
            }
        }

        public double Calories => BASE_CALORIES * Grams * FlourTypeModifier * BakingTechniqueModifier;

        public override string ToString() => $"{Calories:F2}";
    }
}
