using System;

namespace _05.SuitcasesLoad
{
    class SuitcasesLoad
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());

            string end = "End";
            string input = null;

            int suitcaseCounter = 0;

            while (input != end)
            {
                input = Console.ReadLine();

                if (input == end)
                {
                    break;
                }

                double suitcaseVolume = double.Parse(input);

                suitcaseCounter++;

                if (suitcaseCounter % 3 == 0)
                {
                    suitcaseVolume *= 1.1;
                }

                capacity -= suitcaseVolume;

                if (capacity < 0)
                {
                    suitcaseCounter--;
                    break;
                }
            }

            if (capacity < 0)
            {
                Console.WriteLine("No more space!");
            }

            else
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {suitcaseCounter} suitcases loaded.");
        }
    }
}
