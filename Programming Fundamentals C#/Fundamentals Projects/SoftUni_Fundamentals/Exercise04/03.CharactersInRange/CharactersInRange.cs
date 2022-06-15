using System;

namespace _03.CharactersInRange
{
    class CharactersInRange
    {
        static void Main(string[] args)
        {
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            CharsInRange(symbol1, symbol2);
        }

        static void CharsInRange(char symbol1, char symbol2)
        {
            char startingChar = (char)Math.Min(symbol1, symbol2);
            char endingChar = (char)Math.Max(symbol1, symbol2);

            for (int currChar = startingChar + 1; currChar < endingChar; currChar++)
            {
                Console.Write($"{(char)currChar} ");
            }
        }
    }
}
