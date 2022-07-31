using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class EmojiDetector
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            string thresholdPattern = @"\d";
            MatchCollection numbersMatches = Regex.Matches(inputText, thresholdPattern);
            BigInteger coolThresholdSum = BigInteger.One;

            foreach (Match match in numbersMatches)
            {
                coolThresholdSum *= BigInteger.Parse(match.Value);
            }

            string emojiPattern = @"(?<surr>:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\k<surr>";
            MatchCollection emojiMatches = Regex.Matches(inputText, emojiPattern);
            StringBuilder coolEmojis = new StringBuilder();

            foreach (Match match in emojiMatches)
            {
                StringBuilder emoji = new StringBuilder();
                emoji.Append(match.Groups["emoji"].Value);
                BigInteger emojiSum = BigInteger.Zero;

                foreach (char ch in emoji.ToString())
                {
                    emojiSum += ch;
                }

                if (emojiSum > coolThresholdSum)
                {
                    coolEmojis.AppendLine(match.ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(coolEmojis);
        }
    }
}
