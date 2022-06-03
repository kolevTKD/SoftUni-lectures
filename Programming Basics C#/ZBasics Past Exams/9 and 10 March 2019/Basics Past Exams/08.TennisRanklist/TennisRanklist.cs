using System;

namespace _08.TennisRanklist
{
    class TennisRanklist
    {
        static void Main(string[] args)
        {
            int tournamentsNum = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int winsCount = 0;
            int totalPoints = startingPoints;
            int points = 0;

            for (int currentTournament = 1; currentTournament <= tournamentsNum; currentTournament++)
            {
                string stage = Console.ReadLine();

                if (stage == "W")
                {
                    points = 2000;
                    winsCount++;
                }

                else if (stage == "F")
                {
                    points = 1200;
                }

                else if (stage == "SF")
                {
                    points = 720;
                }

                totalPoints += points;
            }

            double avgPoints = (double)(totalPoints - startingPoints) / tournamentsNum;
            double tournamentsWonP = (double)winsCount / tournamentsNum * 100;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(avgPoints)}");
            Console.WriteLine($"{tournamentsWonP:f2}%");
        }
    }
}
