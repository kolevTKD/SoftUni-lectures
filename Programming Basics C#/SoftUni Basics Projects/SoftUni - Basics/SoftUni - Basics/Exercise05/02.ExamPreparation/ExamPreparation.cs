using System;

namespace _02.ExamPreparation
{
    class ExamPreparation
    {
        static void Main(string[] args)
        {
            int poorGrades = int.Parse(Console.ReadLine());
            int numberOfProblems = 0;
            int grade = 0;
            int poorCounter = 0;
            string enough = "Enough";
            string problemName = null;
            string lastProblem = null;
            double totalScore = 0;

            while (poorCounter < poorGrades)
            {
                problemName = Console.ReadLine();

                if (problemName == enough)
                {
                    double avgScore = totalScore / numberOfProblems;

                    Console.WriteLine($"Average score: {avgScore:f2}");
                    Console.WriteLine($"Number of problems: {numberOfProblems}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    return;
                }
                grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    poorCounter++;
                }

                numberOfProblems++;
                lastProblem = problemName;
                totalScore += grade;
            }
            Console.WriteLine($"You need a break, {poorCounter} poor grades.");
        }
    }
}
