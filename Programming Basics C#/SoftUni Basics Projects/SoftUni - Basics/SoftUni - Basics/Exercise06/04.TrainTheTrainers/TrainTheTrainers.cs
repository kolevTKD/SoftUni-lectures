using System;

namespace _04.TrainTheTrainers
{
    class TrainTheTrainers
    {
        static void Main(string[] args)
        {
            int judgesNum = int.Parse(Console.ReadLine());
            int gradesNum = 0;
            double totalAvg = 0;
            string finish = "Finish";
            string input = "";

            while (input != finish)
            {
                input = Console.ReadLine();
                if (input == finish)
                {
                    break;
                }

                double gradesPerPresentation = 0;

                for (int presentationsNum = 1; presentationsNum <= judgesNum; presentationsNum++)
                {
                    double newGrade = double.Parse(Console.ReadLine());
                    gradesPerPresentation += newGrade;
                    gradesNum++;
                    totalAvg += newGrade;
                }

                double gradesAvg = gradesPerPresentation / judgesNum;
                Console.WriteLine($"{input} - {gradesAvg:f2}.");
            }
            totalAvg /= gradesNum;
            Console.WriteLine($"Student's final assessment is {totalAvg:f2}.");
        }
    }
}
