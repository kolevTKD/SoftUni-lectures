using System;
using System.Linq;

namespace _04.WordFilter
{
    class WordFilter
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word.Length % 2 == 0)
                .ToArray();

            foreach (string word in words)
            {
                Console.WriteLine($"{word}");
            }
        }
    }
}
