namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double DEFAULT_FISH_GRAMS = 22.0;
        public Fish (string name, decimal price)
            : base (name, price, DEFAULT_FISH_GRAMS)
        {
        }

        public override double Grams => DEFAULT_FISH_GRAMS;
    }
}
