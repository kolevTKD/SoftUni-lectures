using System;

namespace _11.BasketballTournament
{
    class BasketballTournament
    {
        static void Main(string[] args)
        {
            string end = "End of tournaments";
            string name = null;
            int wins = 0;
            int loses = 0;
            int matchesC = 0;

            while (name != end)
            {
                name = Console.ReadLine();

                if (name == end)
                {
                    break;
                }

                int matches = int.Parse(Console.ReadLine());

                for (int currentMatch = 1; currentMatch <= matches; currentMatch++)
                {
                    matchesC++;
                    int homeResult = int.Parse(Console.ReadLine());
                    int awayResult = int.Parse(Console.ReadLine());
                    int result = 0;

                    if (homeResult > awayResult)
                    {
                        wins++;
                        result = homeResult - awayResult;
                        Console.WriteLine($"Game {currentMatch} of tournament {name}: win with {result} points.");
                    }

                    else if (awayResult > homeResult)
                    {
                        loses++;
                        result = awayResult - homeResult;
                        Console.WriteLine($"Game {currentMatch} of tournament {name}: lost with {result} points.");
                    }
                }
            }

            double wonP = (double)wins / matchesC * 100;
            double lostP = (double)loses / matchesC * 100;
            Console.WriteLine($"{wonP:f2}% matches win");
            Console.WriteLine($"{lostP:f2}% matches lost");
        }
    }
}
