using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int currentLength = 0;
            int longest = 0;
            int[] bestSequence = new int[longest];

            for (int index = 0; index < numbers.Length - 1; index++)
            {
                if (numbers[index] == numbers[index + 1])
                {
                    currentLength = 0;
                    currentLength++;

                    for (int currIndex = index + 1; currIndex <= numbers.Length - 1; currIndex++)
                    {
                        if (numbers[index] != numbers[currIndex])
                        {
                            break;
                        }
                        currentLength++;
                    }
                }

                if (currentLength > longest)
                {
                    longest = currentLength;

                    int[] sequence = new int[longest];

                    for (int i = 0; i < longest; i++)
                    {
                        sequence[i] = numbers[index];
                    }
                    bestSequence = sequence;
                }
            }
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}
