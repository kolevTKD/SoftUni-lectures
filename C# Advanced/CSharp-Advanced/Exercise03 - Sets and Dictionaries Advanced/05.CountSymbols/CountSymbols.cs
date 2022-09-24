using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class CountSymbols
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbolsCount = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!symbolsCount.ContainsKey(input[i]))
                {
                    symbolsCount.Add(input[i], 0);
                }

                symbolsCount[input[i]]++;
            }

            foreach (var kvp in symbolsCount)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
