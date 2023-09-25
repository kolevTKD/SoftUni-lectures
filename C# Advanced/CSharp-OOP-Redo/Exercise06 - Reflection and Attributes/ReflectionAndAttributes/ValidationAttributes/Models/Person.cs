namespace ValidationAttributes.Models
{
    using Utilities.Attributes;

    public class Person
    {
        private const int MIN_VALUE = 12;
        private const int MAX_VALUE = 90;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }
        [MyRange(MIN_VALUE, MAX_VALUE)]
        public int Age { get; private set; }
    }
}
