namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    name = value;
                }
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    age = value;
                }
            }
        }
        public virtual string Gender
        {
            get { return gender; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    gender = value;
                }
            }
        }

        public virtual string ProduceSound() => "Animal sound!";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}")
              .AppendLine($"{Name} {Age} {Gender}")
              .AppendLine($"{ProduceSound()}");

            return sb.ToString().Trim();
        }
    }
}
