using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            string phones = Console.ReadLine();
            string pattern = @"\+359(?<sep>\s|\-)2\k<sep>[0-9]{3}\k<sep>[0-9]{4}\b";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(phones);

            Console.Write(string.Join(", ", matches));
        }
    }
}
