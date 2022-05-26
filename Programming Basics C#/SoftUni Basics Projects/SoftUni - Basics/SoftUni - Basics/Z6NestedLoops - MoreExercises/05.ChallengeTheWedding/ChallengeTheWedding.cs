using System;

namespace _05.ChallengeTheWedding
{
    class ChallengeTheWedding
    {
        static void Main(string[] args)
        {
            int maleClients = int.Parse(Console.ReadLine());
            int femaleClients = int.Parse(Console.ReadLine());
            int maxTablesNum = int.Parse(Console.ReadLine());
            int totalSeats = maxTablesNum * 2;
            int totalDates = maleClients * femaleClients;
            int totalDatesCounter = 0;

            for (int talonsNum = 1; talonsNum <= totalSeats; talonsNum++)
            {
                for (int males = 1; males <= maleClients; males++)
                {
                    for (int females = 1; females <= femaleClients; females++)
                    {
                        totalDatesCounter++;

                        if (totalDatesCounter > maxTablesNum)
                        {
                            return;
                        }

                        Console.Write($"({males} <-> {females}) ");
                    }
                }

                if (totalDatesCounter == totalDates)
                {
                    return;
                }
            }
        }
    }
}
