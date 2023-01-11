using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> models = new List<ISubject>();
        public IReadOnlyCollection<ISubject> Models { get => models; }

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }

        public ISubject FindById(int id)
        {
            return Models.FirstOrDefault(s => s.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return Models.FirstOrDefault(s => s.Name == name);
        }
    }
}
