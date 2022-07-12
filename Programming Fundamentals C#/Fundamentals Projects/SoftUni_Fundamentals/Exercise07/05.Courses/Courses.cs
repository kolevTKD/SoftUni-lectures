using System;
using System.Collections.Generic;

namespace _05.Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            string[] currnetCourse = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            string end = "end";
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (currnetCourse[0] != end)
            {
                string courseName = currnetCourse[0];
                string studentName = currnetCourse[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);
                currnetCourse = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
