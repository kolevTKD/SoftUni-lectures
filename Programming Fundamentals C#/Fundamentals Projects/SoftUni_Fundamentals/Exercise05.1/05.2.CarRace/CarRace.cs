using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._2.CarRace
{
    internal class CarRace
    {
        static void Main(string[] args)
        {
            List<int> track = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            double sumLeft = 0;

            for (int left = 0; left < track.Count / 2; left++)
            {
                if (track[left] == 0)
                {
                    sumLeft *= 0.8;
                }

                sumLeft += track[left];
            }

            double sumRight = 0;

            for (int right = track.Count - 1; right > track.Count / 2; right--)
            {
                if (track[right] == 0)
                {
                    sumRight *= 0.8;
                }

                sumRight += track[right];
            }

            int integer = 0;
            bool leftIsInt = int.TryParse(sumLeft.ToString(), out integer);
            bool rightIsInt = int.TryParse(sumRight.ToString(), out integer);

            if (sumLeft < sumRight)
            {
                Console.WriteLine(leftIsInt 
                    ? $"The winner is left with total time: {sumLeft}"
                    : $"The winner is left with total time: {sumLeft:f1}");
            }

            else if (sumRight < sumLeft)
            {
                Console.WriteLine(rightIsInt 
                    ? $"The winner is right with total time: {sumRight}"
                    : $"The winner is right with total time: {sumRight:f1}");
            }
        }
    }
}
