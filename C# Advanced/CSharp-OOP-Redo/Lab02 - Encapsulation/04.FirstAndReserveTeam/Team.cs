namespace PersonsInfo
{
    using System.Collections.Generic;
    using System.Text;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name { get; private set; }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get => firstTeam.AsReadOnly();
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get => reserveTeam.AsReadOnly();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"First team has {FirstTeam.Count} players.")
              .AppendLine($"Reserve team has {ReserveTeam.Count} players.");

            return sb.ToString().Trim();
        }          
    }
}
