using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class KaminoFactory
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] DNA = new int[length];
            int dnaSum = 0;
            int dnaCount = -1;
            int dnaStartIndex = -1;
            int dnaSamples = 0;
            string cloneThem = "Clone them!";

            int sample = 0;

            while (input != cloneThem)
            {
                sample++;
                int[] currDNA = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDNASum = 0;
                bool isCurrDNABetter = false;

                int count = 0;

                for (int index = 0; index < currDNA.Length; index++)
                {
                    if (currDNA[index] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;

                    if (count > currCount)
                    {
                        currCount = count;
                        currEndIndex = index;
                    }
                }

                currStartIndex = currEndIndex - currCount + 1;
                currDNASum = currDNA.Sum();

                if (currCount > dnaCount)
                {
                    isCurrDNABetter = true;
                }

                else if (currCount == dnaCount)
                {
                    if (currStartIndex < dnaStartIndex)
                    {
                        isCurrDNABetter = true;
                    }

                    else if (dnaStartIndex == currStartIndex)
                    {
                        if (currDNASum > dnaSum)
                        {
                            isCurrDNABetter = true;
                        }
                    }
                }

                if (isCurrDNABetter)
                {
                    DNA = currDNA;
                    dnaCount = currCount;
                    dnaStartIndex = currStartIndex;
                    dnaSum = currDNASum;
                    dnaSamples = sample;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine($"{string.Join(' ', DNA)}");
        }
    }
}
