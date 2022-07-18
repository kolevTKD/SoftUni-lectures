using System;

namespace _08.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            const int UPPER = 64;
            const int LOWER = 96;
            string[] inputSequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double result = 0;

            for (int index = 0; index < inputSequence.Length; index++)
            {
                string currentSequence = inputSequence[index];
                char firstLetter = currentSequence[0];
                char lastLetter = currentSequence[currentSequence.Length - 1];
                double number = double.Parse(currentSequence.Substring(1, currentSequence.Length - 2));
                int firstLetterPos = 0;
                int lastLetterPos = 0;

                if (firstLetter == char.ToUpper(firstLetter))
                {
                    firstLetterPos = firstLetter - UPPER;

                    if (number != 0)
                    {
                        result += number / firstLetterPos;
                    }
                }

                else
                {
                    firstLetterPos = firstLetter - LOWER;
                    result += number * firstLetterPos;
                }

                if (lastLetter == char.ToUpper(lastLetter))
                {
                    lastLetterPos = lastLetter - UPPER;
                    result -= lastLetterPos;
                }

                else
                {
                    lastLetterPos = lastLetter - LOWER;
                    result += lastLetterPos;
                }
            }

            Console.WriteLine($"{result:F2}");
        }
    }
}
