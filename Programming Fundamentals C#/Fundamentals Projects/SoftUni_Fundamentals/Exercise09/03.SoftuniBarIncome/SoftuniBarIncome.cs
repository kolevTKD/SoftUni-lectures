using System;
using System.Text.RegularExpressions;

namespace _03.SoftuniBarIncome
{
    class SoftuniBarIncome
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            string end = "end of shift";
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>[\d]+.?[\d]+)\$";
            double totalSum = 0;

            while (inputLine != end)
            {
                Match match = Regex.Match(inputLine, pattern);

                if (match.Success)
                {
                    string customerName = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double totalForCustomer = count * price;
                    totalSum += totalForCustomer;

                    Console.WriteLine($"{customerName}: {product} - {totalForCustomer:f2}");
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
