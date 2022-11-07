namespace BirthdayCelebrations.Core
{
    using System.Collections.Generic;

    using BirthdayCelebrations.IO.Contracts;
    using BirthdayCelebrations.Models;
    using BirthdayCelebrations.Models.Contracts;
    using Contracts;

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
            string cmd;
            List<ICitizen> subjects = new List<ICitizen>();

            while ((cmd = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(' ');
                string subjectType = cmdArgs[0];
                string subjectName = cmdArgs[1];

                if (subjectType == "Citizen")
                {
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthdate = cmdArgs[4];

                    ICitizen citizen = new Citizen(subjectName, age, id, birthdate);
                    subjects.Add(citizen);
                }

                else if (subjectType == "Pet")
                {
                    string birthdate = cmdArgs[2];

                    ICitizen pet = new Pet(subjectName, birthdate);
                    subjects.Add(pet);
                }
            }

            string year = this.reader.ReadLine();

            foreach (ICitizen subject in subjects)
            {
                string subjectYear = GetYear(subject, year);

                if (subjectYear == year)
                {
                    this.writer.WriteLine(subject.Birthdate);
                }
            }
        }

        private string GetYear(ICitizen subject, string year)
        {
            int startIndex = subject.Birthdate.Length - year.Length;
            string subjectYear = subject.Birthdate.Substring(startIndex);

            return subjectYear;
        }
    }
}
