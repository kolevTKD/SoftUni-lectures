using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class MatchDates
    {
        static void Main(string[] args)
        {
            string dateInputs = Console.ReadLine();
            string pattern = @"(?<day>[0-3][0-9])(?<sep>\.|\/|\-)(?<month>[A-Z][a-z]{2})\k<sep>(?<year>[0-9]{4})";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(dateInputs);

            foreach (Match match in matches)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
