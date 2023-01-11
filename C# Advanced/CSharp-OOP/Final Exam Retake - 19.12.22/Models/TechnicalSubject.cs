using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        private const double SUBJECT_RATE = 1.30;
        public TechnicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, SUBJECT_RATE)
        {
        }
    }
}
