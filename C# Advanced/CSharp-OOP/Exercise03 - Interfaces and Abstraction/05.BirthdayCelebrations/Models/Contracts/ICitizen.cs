namespace BirthdayCelebrations.Models.Contracts
{
    public interface ICitizen
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }
    }
}
