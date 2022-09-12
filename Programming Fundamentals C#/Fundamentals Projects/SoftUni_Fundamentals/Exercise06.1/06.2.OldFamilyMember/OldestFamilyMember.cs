using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._2.OldFamilyMember
{
    internal class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            Family family = GetInfo();
            Person oldest = family.GetOldest();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }

        static Family GetInfo()
        {
            int people = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < people; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            return family;
        }
    }

    class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }
        public List<Person> Members { get; set; }

        public void AddMember(Person person)
        {
            Members.Add(person);
        }

        public Person GetOldest()
        {
            Members = Members.OrderByDescending(x => x.Age).ToList();

            return Members[0];
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
