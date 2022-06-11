using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] DNA = new int[length];
            string cloneThem = "Clone them!";
            string input = null;
            int currentIndex = 0;
            int bestIndex = length;
            int currentSum = 0;
            int bestSum = 0;
            int currentLongest = 0;
            int theLongest = 0;
            int sequenceIndex = 0;
            int bestSequenceIndex = 0;
            int sequenceSum = 0;

            int[] theBest = new int[length - 1];
            int[] currentBest = new int[length - 1];

            while (input != cloneThem)
            {
                input = Console.ReadLine();

                if (input == cloneThem)
                {
                    break;
                }

                DNA = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sequenceIndex++;
                currentIndex = 0;
                currentSum = 0;
                currentLongest = 0;

            }
        }
    }
}
