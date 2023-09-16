namespace FoodShortage.Models
{
    using Contracts;

    public class Citizen : ICitizen, IIdentifiable, IBirthable, IBuyer
    {
        private int food;
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string BirthDate { get; private set; }
        public int Food
        {
            get => food;
            private set => food = value;
        }

        public void BuyFood() => Food += 10;
    }
}
