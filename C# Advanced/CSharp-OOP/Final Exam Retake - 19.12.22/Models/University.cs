using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;

        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            this.Id = universityId;
            this.Name = universityName;
            this.Category = category;
            this.Capacity = capacity;
            this.requiredSubjects = new List<int>(requiredSubjects);
        }
        public int Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                this.name = value;
            }
        }

        public string Category
        {
            get => this.category;
            private set
            {
                if (!(value == "Technical" || value == "Economical" || value == "Humanity"))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }

                this.category = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }

                this.capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects { get => this.requiredSubjects; }
    }
}
