using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person noNameNoAge = new Person();

            Person noName = new Person(18);

            Person jose = new Person("Jose", 43);

            Console.WriteLine($"{noNameNoAge.Name} is {noNameNoAge.Age} years old.");
            Console.WriteLine($"{noName.Name} is {noName.Age} years old.");
            Console.WriteLine($"{jose.Name} is {jose.Age} years old.");
        }
    }
}
