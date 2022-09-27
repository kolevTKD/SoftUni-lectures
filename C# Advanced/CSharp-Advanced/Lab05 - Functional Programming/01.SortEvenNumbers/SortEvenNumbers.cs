using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    internal class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ",
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray()));
        }
    }
}
