using System;

namespace _04.SymbolInMatrix
{
    internal class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] symbols = new char[size][];

            for (int row = 0; row < symbols.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                symbols[row] = new char[input.Length];

                for (int col = 0; col < symbols.Length; col++)
                {
                    symbols[row][col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < symbols.Length; row++)
            {
                for (int col = 0; col < symbols[row].Length; col++)
                {
                    if (symbols[row][col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
