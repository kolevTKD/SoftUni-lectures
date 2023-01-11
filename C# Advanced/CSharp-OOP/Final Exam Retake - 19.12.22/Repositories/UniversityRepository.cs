using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models = new List<IUniversity>();
        public IReadOnlyCollection<IUniversity> Models { get => this.models; }

        public void AddModel(IUniversity model)
        {
            models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return Models.FirstOrDefault(u => u.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return Models.FirstOrDefault(u => u.Name == name);
        }
    }
}
