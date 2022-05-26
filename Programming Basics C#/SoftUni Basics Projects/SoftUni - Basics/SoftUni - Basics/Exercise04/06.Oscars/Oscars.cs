using System;

namespace _06.Oscars
{
    class Oscars
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int judges = int.Parse(Console.ReadLine());
            double pointsForOscar = 1250.5;
            double currentPoints = academyPoints;
            double gradingScale = 0;

            for (int i = 1; i <= judges; i++)
            {
                string judgeName = Console.ReadLine();
                double judgePoints = double.Parse(Console.ReadLine());
                gradingScale = currentPoints + judgeName.Length * judgePoints / 2;
                currentPoints = gradingScale;

                if (currentPoints >= pointsForOscar)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {currentPoints:f1}!");
                    return;
                }
            }
            double pointsNeeded = pointsForOscar - currentPoints;
            Console.WriteLine($"Sorry, {actorName} you need {pointsNeeded:f1} more!");
        }
    }
}
