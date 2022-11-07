namespace FoodShortage.Models.Contracts
{
    public interface ICitizen : IPerson
    {
        public string Id { get; }
        public string Birthdate { get; }
    }
}
