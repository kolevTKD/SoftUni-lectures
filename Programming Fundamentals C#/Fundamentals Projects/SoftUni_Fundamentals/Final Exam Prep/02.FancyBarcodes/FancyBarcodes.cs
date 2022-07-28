using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class FancyBarcodes
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string pattern = @"^@#+([A-Z]+[A-Za-z\d]{4,}[A-Z]+)@#+$";

            for (int product = 1; product <= count; product++)
            {
                string barcode = Console.ReadLine();
                Match barcodeRegex = Regex.Match(barcode, pattern);
                StringBuilder group = new StringBuilder();

                if (!barcodeRegex.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }

                else if (barcodeRegex.Success)
                {
                    foreach (char ch in barcode)
                    {
                        if (char.IsDigit(ch))
                        {
                            group.Append(ch);
                        }
                    }

                    if (group.Length == 0)
                    {
                        group.Append("00");
                    }

                    Console.WriteLine($"Product group: {group}");
                }
            }
        }
    }
}
