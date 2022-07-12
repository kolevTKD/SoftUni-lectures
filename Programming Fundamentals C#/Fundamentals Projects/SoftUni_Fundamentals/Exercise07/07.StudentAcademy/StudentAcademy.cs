using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsInfo = new Dictionary<string, List<double>>();

            for (int studentNum = 1; studentNum <= studentsCount; studentNum++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!studentsInfo.ContainsKey(studentName))
                {
                    studentsInfo.Add(studentName, new List<double>());
                }

                studentsInfo[studentName].Add(studentGrade);
            }

            foreach (var student in studentsInfo)
            {
                double avgGrade = student.Value.Average();

                if (avgGrade >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {avgGrade:f2}");
                }
            }
        }
    }
}
