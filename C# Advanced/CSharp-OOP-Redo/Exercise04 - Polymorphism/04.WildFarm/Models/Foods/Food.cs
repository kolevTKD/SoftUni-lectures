namespace WildFarm.Models.Foods
{
    using Contracts;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; protected set; }

        public override string ToString() => GetType().Name;
    }
}
