using System;

namespace _02.BonusScore
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            int startingPoints = int.Parse(Console.ReadLine());
            int even = 1;
            int endFive = 2;

            double bonusPoints = 0.0;
            double twentyPercent = 0.2;
            double tenPercent = 0.1;

            bool lessHundred = startingPoints <= 100;
            bool betweenHundredThousand = startingPoints > 100 && startingPoints < 1000;
            bool greaterThousand = startingPoints >= 1000;
            bool evenPoints = startingPoints % 2 == 0;
            bool endFivePoints = startingPoints % 10 == 5;

            if (lessHundred)
            {
                bonusPoints = 5;
            }

            else if (betweenHundredThousand)
            {
                bonusPoints = startingPoints * twentyPercent;
            }

            else if (greaterThousand)
            {
                bonusPoints = startingPoints * tenPercent;
            }

            if (evenPoints)
            {
                bonusPoints = bonusPoints + even;
            }

            else if (endFivePoints)
            {
                bonusPoints = bonusPoints + endFive;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(startingPoints + bonusPoints);
        }
    }
}
