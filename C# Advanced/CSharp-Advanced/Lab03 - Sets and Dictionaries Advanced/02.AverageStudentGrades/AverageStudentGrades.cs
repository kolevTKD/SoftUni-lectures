using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int current = 0; current < count; current++)
            {
                string[] studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string studentName = studentInfo[0];
                decimal studentGrade = decimal.Parse(studentInfo[1]);

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                }

                students[studentName].Add(studentGrade);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
