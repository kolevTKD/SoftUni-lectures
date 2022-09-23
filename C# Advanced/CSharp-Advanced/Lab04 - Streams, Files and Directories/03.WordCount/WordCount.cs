using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader readerWords = new StreamReader(wordsFilePath);
            string[] wordsLine = readerWords.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordUses = new Dictionary<string, int>();

            using (readerWords)
            {
                foreach (string word in wordsLine)
                {
                    wordUses.Add(word, 0);
                }

                StreamReader readerText = new StreamReader(textFilePath);

                using (readerText)
                {
                    string pattern = @"[A-Za-z]+";
                    string textLine = readerText.ReadLine();

                    while (textLine != null)
                    {
                        MatchCollection matches = Regex.Matches(textLine, pattern);

                        foreach (var word in wordUses.ToDictionary(x => x.Key, y => y.Value))
                        {
                            foreach (Match match in matches)
                            {
                                if (match.ToString().ToLower() == word.Key.ToLower())
                                {
                                    wordUses[word.Key]++;
                                }
                            }
                        }

                        textLine = readerText.ReadLine();
                    }

                    wordUses = wordUses.OrderByDescending(y => y.Value).ToDictionary(x => x.Key, y => y.Value);
                }

                StreamWriter writer = new StreamWriter(outputFilePath);

                using (writer)
                {
                    foreach (var kvp in wordUses)
                    {
                        writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}


