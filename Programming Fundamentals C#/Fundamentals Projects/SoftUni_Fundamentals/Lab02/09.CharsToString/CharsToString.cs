using System;

namespace _09.CharsToString
{
    class CharsToString
    {
        static void Main(string[] args)
        {
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            char symbol3 = char.Parse(Console.ReadLine());
            string sequence = $"{symbol1}{symbol2}{symbol3}";
            Console.WriteLine(sequence);
        }
    }
}
