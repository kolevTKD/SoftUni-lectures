namespace ExplicitInterfaces.Core
{
    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

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
            string input = string.Empty;

            while((input = reader.ReadLine()) != "End")
            {
                string[] citizenInfo = input.Split(' ');
                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;

                writer.WriteLine(person.GetName());
                writer.WriteLine(resident.GetName());
            }
        }
    }
}
