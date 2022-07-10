using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
{
    class Students2
    {
        static void Main(string[] args)
        {
            string[] studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string firstName = "";
            string lastName = "";
            int age = 0;
            string homeTown = "";
            string end = "end";
            List<Student> students = new List<Student>();

            while (studentInfo[0] != end)
            {
                firstName = studentInfo[0];
                lastName = studentInfo[1];
                age = int.Parse(studentInfo[2]);
                homeTown = studentInfo[3];


                if (ContainsStudent(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;
                }

                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown
                    };

                    students.Add(student);
                }

                studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            string town = Console.ReadLine();

            foreach (Student student in students)
            {
                if (town == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static bool ContainsStudent(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }
    }

    class Student
    {
        //public Student(string firstName, string lastName, int age, string homeTown)
        //{
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    this.Age = age;
        //    this.HomeTown = homeTown;
        //}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
