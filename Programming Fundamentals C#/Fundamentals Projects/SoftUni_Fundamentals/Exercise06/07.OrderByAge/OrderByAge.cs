using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class OrderByAge
    {
        static void Main(string[] args)
        {
            string[] personalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string end = "End";
            List<Person> people = new List<Person>();

            while (personalInfo[0] != end)
            {
                string name = personalInfo[0];
                string id = personalInfo[1];
                int age = int.Parse(personalInfo[2]);
                Person person = new Person(name, id, age);
                people.Add(person);

                personalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            people = people.OrderBy(age => age.Age).ToList();

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"{Name} with ID: {Id} is {Age} years old.";
        
    }
}
