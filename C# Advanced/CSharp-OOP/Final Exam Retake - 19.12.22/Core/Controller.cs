using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjectRepository;
        private StudentRepository studentRepository;
        private UniversityRepository universityRepository;

        public Controller()
        {
            subjectRepository = new SubjectRepository();
            studentRepository = new StudentRepository();
            universityRepository = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (!(subjectType == "EconomicalSubject" || subjectType == "HumanitySubject" || subjectType == "TechnicalSubject"))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            ISubject subject = subjectRepository.FindByName(subjectName);

            if (subject != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            else // possible error!!!
            {
                int subjectId = subjectRepository.Models.Count;

                if (subjectType == "EconomicalSubject")
                {
                    subject = new EconomicalSubject(++subjectId, subjectName);
                }

                if (subjectType == "HumanitySubject")
                {
                    subject = new HumanitySubject(++subjectId, subjectName);
                }

                if (subjectType == "TechnicalSubject")
                {
                    subject = new TechnicalSubject(++subjectId, subjectName);
                }
            }

            subjectRepository.AddModel(subject);

            return String.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjectRepository.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = universityRepository.FindByName(universityName);

            if (university != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            else
            {
                List<int> requireSubjectsIds = new List<int>();

                foreach (var subject in subjectRepository.Models)
                {
                    foreach (var reqSubject in requiredSubjects)
                    {
                        if (reqSubject == subject.Name)
                        {
                            requireSubjectsIds.Add(subject.Id);
                        }
                    }
                }

                int universityId = universityRepository.Models.Count;

                university = new University(++universityId, universityName, category, capacity, requireSubjectsIds);
                universityRepository.AddModel(university);

                return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universityRepository.GetType().Name);
            }
        }

        public string AddStudent(string firstName, string lastName)
        {
            IStudent student = studentRepository.FindByName(String.Join(' ', firstName, lastName));

            if (student != null)
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            else
            {
                int studentId = studentRepository.Models.Count;

                student = new Student(++studentId, firstName, lastName);
                studentRepository.AddModel(student);

                return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, studentRepository.GetType().Name);
            }
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = studentRepository.FindById(studentId);
            ISubject subject = subjectRepository.FindById(subjectId);

            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = studentRepository.FindByName(studentName);
            string[] studentFullName = studentName.Split(' ');
            string firstName = studentFullName[0];
            string lastName = studentFullName[1];

            IUniversity university = universityRepository.FindByName(universityName);

            if (student == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            if (!student.CoveredExams.All(university.RequiredSubjects.Contains))
            {
                return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University == null)
            {
                string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            student.JoinUniversity(university);

            return String.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }


        public string UniversityReport(int universityId)
        {
            IUniversity university = universityRepository.FindById(universityId);
            int studentsCount = 0;

            foreach (var student in studentRepository.Models)
            {
                if (student.University.Id == universityId)
                {
                    studentsCount++;
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString().TrimEnd();
        }
    }
}
