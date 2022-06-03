using System;

namespace _07.Darts
{
    class Darts
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            const int POINTS = 301;
            int playerPoints = POINTS;
            int succesfulShots = 0;
            int unsuccsesfulShots = 0;

            while (playerPoints >= 0)
            {
                string multiplier = Console.ReadLine();

                if (multiplier == "Retire")
                {
                    Console.WriteLine($"{name} retired after {unsuccsesfulShots} unsuccessful shots.");
                    return;
                }

                int points = int.Parse(Console.ReadLine());

                if (multiplier == "Double")
                {
                    points *= 2;
                }

                else if (multiplier == "Triple")
                {
                    points *= 3;
                }

                if (playerPoints - points >= 0)
                {
                    playerPoints -= points;
                    succesfulShots++;
                }

                else
                {
                    unsuccsesfulShots++;
                    continue;
                }

                if (playerPoints == 0)
                {
                    Console.WriteLine($"{name} won the leg with {succesfulShots} shots.");
                    return;
                }
            }
        }
    }
}
