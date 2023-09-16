namespace FoodShortage.Models
{
    using Contracts;
    public class Rebel : ICitizen, IRebel, IBuyer
    {
        private int food;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food
        {
            get => food;
            private set => food = value;
        }

        public void BuyFood() => Food += 5;
    }
}
