using System;

namespace _02.FootballResults
{
    class FootballResults
    {
        static void Main(string[] args)
        {
            int win = 0;
            int lost = 0;
            int draw = 0;

            for (int match = 1; match <= 3; match++)
            {
                string matchResult = Console.ReadLine();

                int scoreHome = matchResult[0];
                int scoreAway = matchResult[2];

                if (scoreHome > scoreAway)
                {
                    win++;
                }

                else if (scoreHome < scoreAway)
                {
                    lost++;
                }

                else
                {
                    draw++;
                }
            }

            Console.WriteLine($"Team won {win} games.");
            Console.WriteLine($"Team lost {lost} games.");
            Console.WriteLine($"Drawn games: {draw}");
        }
    }
}
