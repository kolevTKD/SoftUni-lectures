using System;

namespace _02.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int longerWord = Math.Max(words[0].Length, words[1].Length);
            int shorterWord = Math.Min(words[0].Length, words[1].Length);
            int result = 0;
            string word1 = words[0];
            string word2 = words[1];

            for (int index = 0; index < shorterWord; index++)
            {
                char char1 = word1[index];
                char char2 = word2[index];

                result += char1 * char2;
            }

            if (longerWord != shorterWord)
            {
                bool isFirstLonger = word1.Length == longerWord;
                if (isFirstLonger)
                {
                    for (int index = longerWord - 1; index >= shorterWord; index--)
                    {
                        char currentChar = word1[index];
                        result += currentChar;
                    }
                }

                else
                {
                    for (int index = longerWord - 1; index >= shorterWord; index--)
                    {
                        char currentChar = word2[index];
                        result += currentChar;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
