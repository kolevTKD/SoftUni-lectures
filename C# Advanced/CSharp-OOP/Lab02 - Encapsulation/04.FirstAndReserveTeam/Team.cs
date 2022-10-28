using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name { get; set; }
        public IReadOnlyCollection<Person> FirstTeam { get { return this.firstTeam.AsReadOnly(); } }
        public IReadOnlyCollection<Person> ReserveTeam { get { return this.reserveTeam.AsReadOnly(); } }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }

            else
            {
                this.reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            return
                $"First team has {firstTeam.Count} players." + Environment.NewLine +
                $"Reserve team has {reserveTeam.Count} players.";
        }
    }
}
