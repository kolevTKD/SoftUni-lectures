using System;
using System.Linq;

namespace _04.AddVAT
{
    internal class AddVAT
    {
        static void Main(string[] args)
        {
            Func<decimal, string> VAT = x => (x * 1.2M).ToString("f2");

            Console.WriteLine(String.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(VAT)));
        }
    }
}
