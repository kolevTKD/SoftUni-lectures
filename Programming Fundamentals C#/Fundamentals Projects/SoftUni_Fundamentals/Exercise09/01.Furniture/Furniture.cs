using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _01.Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string end = "Purchase";
            string pattern = @">>(?<furniture>[A-Za-z\s]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)";
            double totalSpent = 0;
            Regex regex = new Regex(pattern);
            List<string> furnitures = new List<string>();

            while (input != end)
            {
                Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    string furniture = match.Groups["furniture"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    furnitures.Add(furniture);
                    double currentPrice = price * quantity;
                    totalSpent += currentPrice;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            furnitures.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalSpent:f2}");
        }
    }
}
