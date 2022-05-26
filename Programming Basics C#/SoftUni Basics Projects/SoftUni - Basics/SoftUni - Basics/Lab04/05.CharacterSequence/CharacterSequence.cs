using System;

namespace _05.CharacterSequence
{
    class CharacterSequence
    {
        static void Main(string[] args)
        {
            string inputWord = Console.ReadLine();

            for (int i = 0; i < inputWord.Length; i++)
            {
                Console.WriteLine(inputWord[i]);
            }
        }
    }
}
