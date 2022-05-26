using System;

namespace _07.Moving
{
    class Moving
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int roomVolume = width * length * height;
            int boxesHousing = 0;
            string done = "Done";

            while (roomVolume >= boxesHousing)
            {
                string input = Console.ReadLine();

                if (input == done)
                {
                    break;
                }

                int boxesNum = int.Parse(input);
                boxesHousing += boxesNum;
            }

            if (boxesHousing <= roomVolume)
            {
                int freeSpace = roomVolume - boxesHousing;
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
            else
            {
                int spaceNeeded = boxesHousing - roomVolume;
                Console.WriteLine($"No more free space! You need {spaceNeeded} Cubic meters more.");
            }
        }
    }
}
