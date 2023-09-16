namespace FoodShortage.Models.Contracts
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
