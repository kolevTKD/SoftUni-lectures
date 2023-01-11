using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        private const double SUBJECT_RATE = 1.00;
        public EconomicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, SUBJECT_RATE)
        {
        }
    }
}
