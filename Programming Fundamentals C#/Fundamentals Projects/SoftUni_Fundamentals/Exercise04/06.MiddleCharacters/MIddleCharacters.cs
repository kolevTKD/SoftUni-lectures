using System;

namespace _06.MiddleCharacters
{
    class MIddleCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(MidChar(input));
        }

        static string MidChar(string input)
        {
            string midChar = string.Empty;

            if (input.Length % 2 == 0)
            {
                midChar += input[input.Length / 2 - 1];
            }

            midChar += input[input.Length / 2];

            return midChar;
        }
    }
}
