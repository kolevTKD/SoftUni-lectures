using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class DestinationMapper
    {
        static void Main(string[] args)
        {
            string locationsInput = Console.ReadLine();
            string locationPattern = @"(?<surr>=|/)(?<location>[A-Z][A-Za-z]{2,})\k<surr>";
            MatchCollection locations = Regex.Matches(locationsInput, locationPattern);
            List<string> destinations = new List<string>();
            int travelPoints = 0;

            foreach (Match location in locations)
            {
                travelPoints += location.Groups["location"].Length;
                destinations.Add(location.Groups["location"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
