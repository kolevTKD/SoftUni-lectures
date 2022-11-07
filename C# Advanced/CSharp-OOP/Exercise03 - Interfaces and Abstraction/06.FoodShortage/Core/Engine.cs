namespace FoodShortage.Core
{
    using FoodShortage.Core.Contracts;
    using FoodShortage.IO.Contracts;
    using FoodShortage.Models;
    using FoodShortage.Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            int count = int.Parse(this.reader.ReadLine());
            List<IPerson> people = new List<IPerson>();

            for (int i = 0; i < count; i++)
            {
                string[] personInfo = this.reader.ReadLine().Split(' ');
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (GetLength(personInfo) == 3)
                {
                    string group = personInfo[2];

                    IPerson rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }

                else if (GetLength(personInfo) == 4)
                {
                    string id = personInfo[2];
                    string birthdate = personInfo[3];

                    IPerson citizen = new Citizen(name, age, id, birthdate);
                    people.Add(citizen);
                }
            }

            string cmd;

            while ((cmd = this.reader.ReadLine()) != "End")
            {
                string name = cmd;
                BuyFood(people, name);
            }

            int foodAmount = 0;

            foreach(IPerson person in people)
            {
                foodAmount += person.Food;
            }

            this.writer.WriteLine($"{foodAmount}");
        }

        private int GetLength(string[] personInfo) => personInfo.Length;
        private void BuyFood(List<IPerson> people, string name)
        {
            IPerson person = people.FirstOrDefault(p => p.Name == name);

            if (person != default(IPerson))
            {
                person.BuyFood();
            }
        }
    }
}
