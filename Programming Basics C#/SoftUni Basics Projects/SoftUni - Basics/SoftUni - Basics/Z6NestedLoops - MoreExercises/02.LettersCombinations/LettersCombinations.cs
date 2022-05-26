using System;

namespace _02.LettersCombinations
{
    class LettersCombinations
    {
        static void Main(string[] args)
        {
            char letter1Begining = char.Parse(Console.ReadLine());
            char letter2Ending = char.Parse(Console.ReadLine());
            char letter3Invalid = char.Parse(Console.ReadLine());
            int combinationCounter = 0;

            for (char letter1 = letter1Begining; letter1 <= letter2Ending; letter1++)
            {
                bool isValidLetter1 = true;

                if (letter1 == letter3Invalid)
                {
                    isValidLetter1 = false;
                    continue;
                }

                for (char letter2 = letter1Begining; letter2 <= letter2Ending; letter2++)
                {
                    bool isValidLetter2 = true;

                    if (letter2 == letter3Invalid)
                    {
                        isValidLetter2 = false;
                        continue;
                    }

                    for (char letter3 = letter1Begining; letter3 <= letter2Ending; letter3++)
                    {
                        bool isValidLetter3 = true;

                        if (letter3 == letter3Invalid)
                        {
                            isValidLetter3 = false;
                            continue;
                        }

                        if (isValidLetter1 && isValidLetter2 && isValidLetter3)
                        {
                            string combination = $"{letter1}{letter2}{letter3} ";
                            Console.Write(combination);
                            combinationCounter++;
                        }
                    }
                }
            }
            Console.Write(combinationCounter);
        }
    }
}
