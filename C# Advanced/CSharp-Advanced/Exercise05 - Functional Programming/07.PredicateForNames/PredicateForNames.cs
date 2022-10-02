using System;
using System.Linq;

namespace _07.PredicateForNames
{
    internal class PredicateForNames
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isValidLength = (n, l) => n.Length <= l;
            Func<string[], int, Func<string, int, bool>, string[]> filter = (n, l, m) => n = n.Where(n => m(n, l)).ToArray();
            Action<string[]> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            names = filter(names, length, isValidLength);
            print(names);
        }
    }
}
