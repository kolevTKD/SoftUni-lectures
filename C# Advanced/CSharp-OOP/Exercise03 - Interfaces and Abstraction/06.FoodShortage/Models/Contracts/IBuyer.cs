namespace FoodShortage.Models.Contracts
{
    public interface IBuyer
    {
        public int Food { get; }
        void BuyFood();
    }
}
