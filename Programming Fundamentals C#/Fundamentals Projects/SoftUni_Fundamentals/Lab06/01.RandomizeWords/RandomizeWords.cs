using System;
using System.Linq;

namespace _01.RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int index = 0; index < words.Length; index++)
            {
                Random random = new Random();
                int rndIndex = random.Next(words.Length);
                string currentWord = words[index];
                words[index] = words[rndIndex];
                words[rndIndex] = currentWord;
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
