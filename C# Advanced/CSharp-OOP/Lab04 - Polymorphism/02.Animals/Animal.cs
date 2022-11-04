namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name
        {
            get => this.name;
            protected set => this.name = value;
        }

        public string FavouriteFood
        {
            get => this.favouriteFood;
            protected set => this.favouriteFood = value;
        }

        public virtual string ExplainSelf() => $"I am {this.Name} and my favourite food is {this.FavouriteFood}";
    }
}
