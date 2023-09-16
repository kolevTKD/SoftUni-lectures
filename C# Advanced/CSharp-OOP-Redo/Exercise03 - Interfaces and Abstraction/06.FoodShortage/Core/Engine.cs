namespace FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private ICitizen person;

        private List<ICitizen> people;

        private Engine()
        {
            people = new List<ICitizen>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            int lines = int.Parse(reader.ReadLine());

            for (int i = 1; i <= lines; i++)
            {
                string[] subjectInfo = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = subjectInfo[0];
                int age = int.Parse(subjectInfo[1]);

                if (subjectInfo.Length == 4)
                {
                    string id = subjectInfo[2];
                    string birthDate = subjectInfo[3];
                    person = new Citizen(name, age, id, birthDate);
                    people.Add(person);
                }
                else if (subjectInfo.Length == 3)
                {
                    string group = subjectInfo[2];
                    person = new Rebel(name, age, group);
                    people.Add(person);
                }
            }

            string input = string.Empty;

            while ((input = reader.ReadLine()) != "End")
            {
                string name = input;
                IBuyer buyer = (IBuyer)people.FirstOrDefault(n => n.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            int foodAmount = 0;

            foreach (IBuyer person in people)
            {
                foodAmount += person.Food;
            }

            writer.WriteLine(foodAmount.ToString());
        }
    }
}
