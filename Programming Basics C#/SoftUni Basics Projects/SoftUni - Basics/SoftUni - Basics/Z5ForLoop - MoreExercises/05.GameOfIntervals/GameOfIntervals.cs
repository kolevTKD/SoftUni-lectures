using System;

namespace _05.GameOfIntervals
{
    class GameOfIntervals
    {
        static void Main(string[] args)
        {
            int gameTurns = int.Parse(Console.ReadLine());
            double to9Counter = 0;
            double to19Counter = 0;
            double to29Counter = 0;
            double to39Counter = 0;
            double to49Counter = 0;
            double invalidCounter = 0;
            double points = 0;
            double totalPoints = 0;

            for (int i = 1; i <= gameTurns; i++)
            {

                int num = int.Parse(Console.ReadLine());

                bool from0To9 = num >= 0 && num <= 9;
                bool from10To19 = num >= 10 && num <= 19;
                bool from20To29 = num >= 20 && num <= 29;
                bool from30To39 = num >= 30 && num <= 39;
                bool from40To49 = num >= 40 && num <= 50;
                bool invalid = num < 0 || num > 50;

                if (invalid)
                {
                    totalPoints /= 2;
                    invalidCounter++;
                    continue;
                }

                if (from0To9)
                {
                    points = num * 0.2;
                    to9Counter++;
                }

                else if (from10To19)
                {
                    points = num * 0.3;
                    to19Counter++;
                }

                else if (from20To29)
                {
                    points = num * 0.4;
                    to29Counter++;
                }

                else if (from30To39)
                {
                    points = 50;
                    to39Counter++;
                }

                else if (from40To49)
                {
                    points = 100;
                    to49Counter++;
                }
                totalPoints += points;
            }

            double to9P = to9Counter / gameTurns * 100;
            double to19P = to19Counter / gameTurns * 100;
            double to29P = to29Counter / gameTurns * 100;
            double to39P = to39Counter / gameTurns * 100;
            double to49P = to49Counter / gameTurns * 100;
            double invalidP = invalidCounter / gameTurns * 100;

            Console.WriteLine($"{totalPoints:f2}");
            Console.WriteLine($"From 0 to 9: {to9P:f2}%");
            Console.WriteLine($"From 10 to 19: {to19P:f2}%");
            Console.WriteLine($"From 20 to 29: {to29P:f2}%");
            Console.WriteLine($"From 30 to 39: {to39P:f2}%");
            Console.WriteLine($"From 40 to 50: {to49P:f2}%");
            Console.WriteLine($"Invalid numbers: {invalidP:f2}%");
        }
    }
}
