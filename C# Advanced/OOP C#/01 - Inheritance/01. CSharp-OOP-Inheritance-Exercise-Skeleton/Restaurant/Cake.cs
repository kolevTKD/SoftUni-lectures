namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DEFAULT_CAKE_GRAMS = 250.0;
        private const double DEFAULT_CAKE_CALORIES = 1000.0;
        private const decimal DEFAULT_CAKE_PRICE = 5.0m;
        public Cake (string name)
            : base (name, DEFAULT_CAKE_PRICE, DEFAULT_CAKE_GRAMS, DEFAULT_CAKE_CALORIES)
        {
        }

        public override double Grams => DEFAULT_CAKE_GRAMS;
        public override double Calories => DEFAULT_CAKE_CALORIES;
        public override decimal Price => DEFAULT_CAKE_PRICE;
    }
}
