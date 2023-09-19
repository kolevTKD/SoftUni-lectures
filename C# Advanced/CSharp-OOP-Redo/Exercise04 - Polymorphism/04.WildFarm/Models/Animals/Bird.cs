namespace WildFarm.Models.Animals
{
    using Contracts;
    public abstract class Bird : Animal, IBird
    {
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }
        public double WingSize { get; protected set; }

        public override string ToString() => $"{base.ToString()}{WingSize}, {Weight}, {FoodEaten}]";
    }
}
