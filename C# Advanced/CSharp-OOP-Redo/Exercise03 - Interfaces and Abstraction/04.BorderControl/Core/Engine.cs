namespace BorderControl.Core
{
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

        private List<IIdentifiable> subjects;

        private Engine()
        {
            subjects = new List<IIdentifiable>();
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
                string id = string.Empty;

                if (subjectInfo.Length == 3)
                {
                    string name = subjectInfo[0];
                    int age = int.Parse(subjectInfo[1]);
                    id = subjectInfo[2];
                    subject = new Citizen(name, age, id);
                }
                else if (subjectInfo.Length == 2)
                {
                    string model = subjectInfo[0];
                    id = subjectInfo[1];
                    subject = new Robot(model, id);
                }

                subjects.Add(subject);
            }

            string fakeIdDigits = reader.ReadLine();

            foreach(IIdentifiable subject in subjects)
            {
                IdValidator(subject, fakeIdDigits);
            }
        }

        private void IdValidator(IIdentifiable subject, string fakeIdDigits)
        {
            if (subject.Id.EndsWith(fakeIdDigits))
            {
                writer.WriteLine(subject.Id);
            }
        }
    }
}
