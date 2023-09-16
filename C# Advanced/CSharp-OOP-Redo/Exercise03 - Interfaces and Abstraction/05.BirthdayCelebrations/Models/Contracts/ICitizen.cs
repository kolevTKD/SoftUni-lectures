namespace BirthdayCelebrations.Models.Contracts
{
    public interface ICitizen : IIdentifiable, IBirthable
    {
        int Age { get; }
    }
}
