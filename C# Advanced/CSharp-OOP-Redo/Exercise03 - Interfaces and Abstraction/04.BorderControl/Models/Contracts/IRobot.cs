namespace BorderControl.Models.Contracts
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
