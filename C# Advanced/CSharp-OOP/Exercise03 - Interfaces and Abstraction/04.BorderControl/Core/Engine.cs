namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BorderControl.Models;
    using Core.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly ICitizen citizen;
        private readonly IRobot robot;

        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            List<IRobot> citizensAndRobots = new List<IRobot>();
            
            string input;

            while ((input = this.reader.ReadLine()) != "End")
            {
                string[] subject = input.Split(' ');

                if (IsCitizen(subject))
                {
                    string name = subject[0];
                    int age = int.Parse(subject[1]);
                    string id = subject[2];
                    IRobot citizen = new Citizen(name, age, id);

                    citizensAndRobots.Add(citizen);
                }

                else if (!IsCitizen(subject))
                {
                    string model = subject[0];
                    string id = subject[1];
                    IRobot robot = new Robot(model, id);

                    citizensAndRobots.Add(robot);
                }
            }

            string idChecker = this.reader.ReadLine();

            List<string> fakeIds = citizensAndRobots
                .Select(c => c.Id)
                .Where(c => IsFakeId(c, idChecker))
                .ToList();

            this.writer.WriteLine(string.Join(Environment.NewLine, fakeIds));
        }

        private bool IsCitizen(string[] subject) => subject.Length == 3;
        private bool IsFakeId(string id, string idChecker)
        {
            int startIndex = id.Length - idChecker.Length;
            string lastDigits = id.Substring(startIndex);

            if (lastDigits == idChecker) return true;

            return false;
            
        }
    }
}
