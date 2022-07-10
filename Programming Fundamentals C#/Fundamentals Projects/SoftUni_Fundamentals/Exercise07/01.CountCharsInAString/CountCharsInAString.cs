using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class CountCharsInAString
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int index = 0; index < words.Length; index++)
            {
                char[] currentWord = words[index].ToCharArray();

                for (int currIndex = 0; currIndex < currentWord.Length; currIndex++)
                {
                    char currChar = currentWord[currIndex];

                    if (!charsCount.ContainsKey(currChar))
                    {
                        charsCount.Add(currentWord[currIndex], 1);
                        continue;
                    }
                    charsCount[currChar]++;
                }
            }

            foreach (var character in charsCount)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
