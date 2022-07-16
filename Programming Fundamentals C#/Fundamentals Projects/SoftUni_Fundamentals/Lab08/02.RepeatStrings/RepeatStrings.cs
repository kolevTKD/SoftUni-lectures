using System;
using System.Text;

namespace _02.RepeatStrings
{
    class RepeatStrings
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                foreach (char ch in word)
                {
                    result.Append(word);
                }
            }

            Console.WriteLine(result);



            //foreach (string word in words)
            //{
            //    foreach (char ch in word)
            //    {
            //        Console.Write(word);
            //    }
            //}

            //for (int index = 0; index <= words.Length - 1; index++)
            //{
            //    for (int wordIndex = 0; wordIndex <= words[index].Length - 1; wordIndex++)
            //    {
            //        Console.Write(words[index]);
            //    }
            //}
        }
    }
}
