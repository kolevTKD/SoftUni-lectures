using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person peter = new Person()
            {
                Name = "Peter",
                Age = 20
            };

            Person george = new Person();
            george.Name = "George";
            george.Age = 18;
            

            Person jose = new Person()
            {
                Name = "Jose",
                Age = 43
            };

            Console.WriteLine($"{peter.Name} is {peter.Age} years old.");
            Console.WriteLine($"{george.Name} is {george.Age} years old.");
            Console.WriteLine($"{jose.Name} is {jose.Age} years old.");
        }
    }
}
