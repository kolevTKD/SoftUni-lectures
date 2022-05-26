using System;

namespace _08.TenisRanklist
{
    class TenisRanklist
    {
        static void Main(string[] args)
        {
            int tournamentsParticipatedIn = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int currentPoints = startingPoints;
            int w = 2000;
            int f = 1200;
            int sF = 720;
            int won = 0;
            int totalPoints = 0;


            for (int i = 1; i <= tournamentsParticipatedIn; i++)
            {
                string stage = Console.ReadLine();

                if (stage == "W")
                {
                    totalPoints = currentPoints + w;
                    currentPoints = totalPoints;
                    won++;
                }
                else if (stage == "F")
                {
                    totalPoints = currentPoints + f;
                    currentPoints = totalPoints;
                }
                else if (stage == "SF")
                {
                    totalPoints = currentPoints + sF;
                    currentPoints = totalPoints;
                }
            }

            int tournamentsTotal = totalPoints - startingPoints;
            double avgPoints = Math.Floor((double)tournamentsTotal / tournamentsParticipatedIn);
            double pWon = (double)won / tournamentsParticipatedIn * 100;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {avgPoints}");
            Console.WriteLine($"{pWon:f2}%");
        }
    }
}
