namespace Animals
{
    public class Kitten : Cat
    {
        private const string DEFAULT_KITTEN_GENDER = "Female";
        public Kitten (string name, int age)
            : base (name, age, DEFAULT_KITTEN_GENDER)
        {
        }

        public override string Gender => DEFAULT_KITTEN_GENDER;

        public override string ProduceSound() => "Meow";
    }
}
