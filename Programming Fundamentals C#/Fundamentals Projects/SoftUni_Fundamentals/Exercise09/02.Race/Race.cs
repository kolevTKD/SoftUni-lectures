using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Race
    {
        static void Main(string[] args)
        {
            List<string> racers = Console.ReadLine().Split(", ").ToList();
            string currRacer = Console.ReadLine();
            string namePattern = @"(?<name>[A-Za-z+])";
            string scorePattern = @"(?<kilometers>\d+)";
            string end = "end of race";
            Regex nameRegex = new Regex(namePattern);
            Regex kmRegex = new Regex(scorePattern);
            Dictionary<string, int> racersInfo = new Dictionary<string, int>();
 
            while (currRacer != end)
            {
                MatchCollection matchedNames = nameRegex.Matches(currRacer);
                string name = string.Join("", matchedNames);
                MatchCollection matchedDigits = kmRegex.Matches(currRacer);
                string digits = string.Join("", matchedDigits);
                int distance = 0;

                if (racers.Contains(name))
                {
                    for (int index = 0; index < digits.Length; index++)
                    {
                        distance += int.Parse(digits[index].ToString());
                    }

                    if (!racersInfo.ContainsKey(name))
                    {
                        racersInfo.Add(name, distance);
                    }

                    else
                    {
                        racersInfo[name] += distance;
                    }
                }

                currRacer = Console.ReadLine();
            }

            var winners = racersInfo.OrderByDescending(km => km.Value).Take(3);

            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);

            foreach (var firstName in firstPlace)
            {
                Console.WriteLine($"1st place: {firstName.Key}");
            }

            foreach (var secondName in secondPlace)
            {
                Console.WriteLine($"2nd place: {secondName.Key}");
            }

            foreach (var thirdName in thirdPlace)
            {
                Console.WriteLine($"3rd place: {thirdName.Key}");
            }
        }
    }
}
