namespace WildFarm.Models.Food
{
    using Contracts;
    public class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
