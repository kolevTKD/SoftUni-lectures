using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models = new List<IStudent>();
        public IReadOnlyCollection<IStudent> Models { get => this.models; }

        public void AddModel(IStudent model)
        {
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return Models.FirstOrDefault(s => s.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(' ');
            string firstName = fullName[0];
            string lastName = fullName[1];

            return Models.FirstOrDefault(s => s.FirstName == firstName || s.LastName == lastName);
            
        }
    }
}
