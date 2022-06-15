using System;
using System.Linq;

namespace _10.LadyBugs
{
    class LadyBugs
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] ladybugsField = new int[fieldSize];

            string[] occupiedIndexes = Console.ReadLine().Split();

            for (int index = 0; index < occupiedIndexes.Length; index++)
            {
                int currentIndex = int.Parse(occupiedIndexes[index]);

                if (currentIndex >= 0 && currentIndex < fieldSize)
                {
                    ladybugsField[currentIndex] = 1;
                }
            }

            string[] commands = Console.ReadLine().Split();
            string end = "end";

            while (commands[0] != end)
            {
                bool isFirst = true;
                int currentIndex = int.Parse(commands[0]);

                while (currentIndex >= 0 && currentIndex < fieldSize && ladybugsField[currentIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladybugsField[currentIndex] = 0;
                        isFirst = false;
                    }

                    string direction = commands[1];
                    int flightLength = int.Parse(commands[2]);

                    if (direction == "left")
                    {
                        currentIndex -= flightLength;

                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugsField[currentIndex] == 0)
                            {
                                ladybugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }

                    else
                    {
                        currentIndex += flightLength;

                        if(currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugsField[currentIndex] == 0)
                            {
                                ladybugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", ladybugsField));
        }
    }
}
