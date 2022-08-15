using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.ArriveKathmandu
{
    class ArrivingInKathmandu
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<peak>[A-Za-z\d!@#$?]+)=(?<length>\d+)<<(?<code>(.*?)+)$";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Last note")
                {
                    break;
                }

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string nameOfPeak = match.Groups["peak"].Value;
                    int length = int.Parse(match.Groups["length"].Value);
                    string code = match.Groups["code"].Value;

                    if (code.Length != length)
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                    StringBuilder peakName = new StringBuilder();

                    for (int index = 0; index < nameOfPeak.Length; index++)
                    {
                        if (char.IsLetterOrDigit(nameOfPeak[index]))
                        {
                            peakName.Append(nameOfPeak[index]);
                        }
                    }

                    Console.WriteLine($"Coordinates found! {peakName} -> {code}");
                }

                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
