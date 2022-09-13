using System;
using System.Collections.Generic;

namespace _01.ReverseAString
{
    internal class ReverseAString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversed = new Stack<char>();

            foreach (char symbol in input)
            {
                reversed.Push(symbol);
            }

            while (reversed.Count > 0)
            {
                Console.Write(reversed.Pop());
            }
        }
    }
}
