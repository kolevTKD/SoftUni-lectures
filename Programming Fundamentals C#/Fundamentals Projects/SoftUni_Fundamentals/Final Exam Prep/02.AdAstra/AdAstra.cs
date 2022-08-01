using System;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class AdAstra
    {
        static void Main(string[] args)
        {
            const int KCAL_PER_DAY = 2000;
            string text = Console.ReadLine();
            string foodPattern = @"(?<sep>#|\|)(?<itemName>[A-Za-z\s]+)\k<sep>(?<expD>[\d]{2}/[\d]{2}/[\d]{2})\k<sep>(?<cals>[\d]+)\k<sep>";
            int totalCalories = 0;

            MatchCollection productsMatched = Regex.Matches(text, foodPattern);
            foreach (Match match in productsMatched)
            {
                totalCalories += int.Parse(match.Groups["cals"].Value);
            }

            int daysToLast = totalCalories / KCAL_PER_DAY;
            Console.WriteLine($"You have food to last you for: {daysToLast} days!");

            foreach (Match product in productsMatched)
            {
                string itemName = product.Groups["itemName"].Value;
                string expD = product.Groups["expD"].Value;
                int cals = int.Parse(product.Groups["cals"].Value);

                Console.WriteLine($"Item: {itemName}, Best before: {expD}, Nutrition: {cals}");
            }
        }
    }
}
