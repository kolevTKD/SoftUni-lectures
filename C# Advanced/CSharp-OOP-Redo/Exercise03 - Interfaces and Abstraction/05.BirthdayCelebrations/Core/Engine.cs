namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private IIdentifiable subject;
        private IBirthable livingSubject;

        private List<IIdentifiable> subjects;
        private List<IBirthable> livingSubjects;

        private Engine()
        {
            subjects = new List<IIdentifiable>();
            livingSubjects = new List<IBirthable>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string input = string.Empty;

            while ((input = reader.ReadLine()) != "End")
            {
                string[] subjectInfo = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                string type = subjectInfo[0];
                string id = string.Empty;

                if (type == "Citizen")
                {
                    string name = subjectInfo[1];
                    int age = int.Parse(subjectInfo[2]);
                    id = subjectInfo[3];
                    string birthDate = subjectInfo[4];
                    livingSubject = new Citizen(name, age, id, birthDate);
                    livingSubjects.Add(livingSubject);
                }
                else if (type == "Robot")
                {
                    string model = subjectInfo[1];
                    id = subjectInfo[2];
                    subject = new Robot(model, id);
                    subjects.Add(subject);
                }
                else if (type == "Pet")
                {
                    string name = subjectInfo[1];
                    string birthDate = subjectInfo[2];
                    livingSubject = new Pet(name, birthDate);
                    livingSubjects.Add(livingSubject);
                }
            }

            string birthYear = reader.ReadLine();
            ValidateYears(birthYear);
        }

        private void ValidateYears(string birthYear)
        {
            foreach (IBirthable livingSubject in livingSubjects)
            {
                if (livingSubject.BirthDate.EndsWith(birthYear))
                {
                    writer.WriteLine(livingSubject.BirthDate);
                }
            }
        }
    }
}
