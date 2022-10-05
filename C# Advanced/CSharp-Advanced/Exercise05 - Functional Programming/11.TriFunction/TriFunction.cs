using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.TriFunction
{
    internal class TriFunction
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkSum = (name, sum) => name.Sum(ch => ch) >= sum;
            Func<List<string>, int, Func<string, int, bool>, string> getName = (names, sum, match) => names.FirstOrDefault(n => match(n, sum));

            int value = int.Parse(Console.ReadLine());
            List<string> people = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Console.WriteLine(getName(people, value, checkSum));
        }
    }
}
