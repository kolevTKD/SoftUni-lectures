using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            string emailPattern = @"(^|\s)([A-Za-z\d]+)([\.\-_]*)([A-Za-z\d]+)@([A-Za-z\d]+)([\.\-][A-Za-z\d]+)+\b";

            MatchCollection emails = Regex.Matches(inputText, emailPattern);

            foreach (Match email in emails)
            {
                Console.WriteLine(email.Value.Trim());
            }
        }
    }
}
