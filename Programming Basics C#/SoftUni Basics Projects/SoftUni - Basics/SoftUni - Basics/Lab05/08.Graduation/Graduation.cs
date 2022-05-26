using System;

namespace _08.Graduation
{
    class Graduation
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade = 1;
            double gradePerYear = 0;
            double gradesTotal = 0;
            bool hasFailed = false;

            while (grade <= 12)
            {
                gradePerYear = double.Parse(Console.ReadLine());

                if (gradePerYear < 4)
                {
                    if (hasFailed)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                    hasFailed = true;
                    continue;
                }

                gradesTotal += gradePerYear;

                if (grade == 12)
                {
                    double avgGrades = gradesTotal / grade;
                    Console.WriteLine($"{name} graduated. Average grade: {avgGrades:f2}");
                    break;
                }
                grade++;
            }
        }
    }
}
