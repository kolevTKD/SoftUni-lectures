using System;

namespace _01._4.ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string reversedWord = "";

            for (int index = word.Length - 1; index >= 0; index--)
            {
                reversedWord += word[index];
            }
            Console.WriteLine(reversedWord);
        }
    }
}
