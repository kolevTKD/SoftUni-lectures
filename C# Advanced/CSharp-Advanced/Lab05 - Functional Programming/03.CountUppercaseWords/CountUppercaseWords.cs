using System;

namespace _03.CountUppercaseWords
{
    internal class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Predicate<string> isCapitalLetter = x => char.IsUpper(x[0]);

            Console.WriteLine(string.Join("\r\n",
            Array.FindAll(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries), isCapitalLetter)));
        }
    }
}
