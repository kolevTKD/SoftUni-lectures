namespace FoodShortage.Models.Contracts
{
    public interface IBuyer
    {
        int Food { get; }
        void BuyFood();
    }
}
