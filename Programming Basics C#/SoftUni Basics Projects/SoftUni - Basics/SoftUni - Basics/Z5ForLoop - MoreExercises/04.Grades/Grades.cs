using System;

namespace _04.Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            int totalStudents = int.Parse(Console.ReadLine());
            double gradesSum = 0;
            double fail = 0;
            double btwn3And4 = 0;
            double btwn4And5 = 0;
            double topStudents = 0;


            for (int i = 1; i <= totalStudents; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                gradesSum += grade;

                if (grade < 3)
                {
                    fail++;
                }

                else if (grade >= 3 && grade < 4)
                {
                    btwn3And4++;
                }

                else if (grade >= 4 && grade < 5)
                {
                    btwn4And5++;
                }

                else if (grade >= 5)
                {
                    topStudents++;
                }

            }

            double avgGrade = gradesSum / totalStudents;
            double failP = fail / totalStudents * 100;
            double btwn3And4P = btwn3And4 / totalStudents * 100;
            double btwn4And5P = btwn4And5 / totalStudents * 100;
            double topStudentsP = topStudents / totalStudents * 100;

            Console.WriteLine($"Top students: {topStudentsP:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {btwn4And5P:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {btwn3And4P:f2}%");
            Console.WriteLine($"Fail: {failP:f2}%");
            Console.WriteLine($"Average: {avgGrade:f2}");
        }
    }
}
