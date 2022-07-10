using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Students
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

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.HomeTown = homeTown;

                students.Add(student);

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
