using System;

namespace _06.TournamentOfChristmas
{
    class TournamentOfChristmas
    {
        static void Main(string[] args)
        {
            int tournamentDays = int.Parse(Console.ReadLine());
            int winsPerDay;
            int daysWon = 0;
            int losesPerDay;
            int daysLost = 0;

            double sum = 0;

            string finish = "Finish";
            string win = "win";
            string lose = "lose";

            for (int currDay = 1; currDay <= tournamentDays; currDay++)
            {
                string input = null;
                double sumPerDay = 0;
                winsPerDay = 0;
                losesPerDay = 0;

                while (input != finish)
                {
                    input = Console.ReadLine();

                    if (input == finish)
                    {
                        break;
                    }

                    string result = Console.ReadLine();

                    if (result == win)
                    {
                        winsPerDay++;
                        sumPerDay += 20;
                    }

                    else if (result == lose)
                    {
                        losesPerDay++;
                    }
                }

                if (winsPerDay > losesPerDay)
                {
                    daysWon++;
                    sum += sumPerDay * 1.1;
                }
                else
                {
                    daysLost++;
                    sum += sumPerDay;
                }
            }

            if (daysWon > daysLost)
            {
                sum *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {sum:f2}");
            }
            else if (daysLost > daysWon)
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {sum:f2}");
            }
        }
    }
}
