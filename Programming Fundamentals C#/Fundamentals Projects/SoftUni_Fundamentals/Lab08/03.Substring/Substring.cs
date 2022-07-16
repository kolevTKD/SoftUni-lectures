using System;

namespace _03.Substring
{
    class Substring
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string charSequence = Console.ReadLine();

            while (charSequence.Contains(wordToRemove))
            {
                int startIndex = charSequence.IndexOf(wordToRemove);
                charSequence = charSequence.Remove(startIndex, wordToRemove.Length);
            }

            Console.WriteLine(charSequence);
        }
    }
}
