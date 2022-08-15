using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MessageTranslator
{
    class MessageTranslator
    {
        static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());
            string pattern = @"(!(?<command>[A-Z][a-z]{2,})!):\[(?<word>[A-Za-z]{8,})\]";

            for (int i = 1; i <= messagesCount; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    List<int> wordValues = new List<int>();
                    string word = $"{match.Groups["word"].Value}";

                    foreach (char ch in word)
                    {
                        int value = ch;
                        wordValues.Add(value);

                    }

                    Console.WriteLine($"{match.Groups["command"].Value}: {string.Join(" ", wordValues)}");
                }

                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
