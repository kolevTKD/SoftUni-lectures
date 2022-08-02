using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class MirrorWords
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pairPattern = @"(?<sep>\#|\@)(?<word1>[A-Za-z]{3,})\k<sep>{2}(?<word2>[A-Za-z]{3,})\k<sep>";
            MatchCollection wordMatches = Regex.Matches(text, pairPattern);
            List<string> matchedWords = new List<string>();

            if(wordMatches.Count != 0)
            {
                Console.WriteLine($"{wordMatches.Count} word pairs found!");
                

                foreach (Match match in wordMatches)
                {
                    if (match.Groups["word1"].Length == match.Groups["word2"].Length)
                    {
                        StringBuilder reversedWord = new StringBuilder();
                        for (int index = match.Groups["word1"].Length - 1; index >= 0; index--)
                        {
                            reversedWord.Append(match.Groups["word1"].Value[index]);
                        }

                        if (reversedWord.ToString() == match.Groups["word2"].Value)
                        {
                            matchedWords.Add(string.Join(" <=> ", match.Groups["word1"], match.Groups["word2"]));
                        }
                    }
                }
            }

            else if (wordMatches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }

            if (matchedWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");

                return;
            }

            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine($"{string.Join(", ", matchedWords)}");
            }
        }
    }
}
