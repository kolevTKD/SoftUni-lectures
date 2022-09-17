using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
    internal class BalancedParentheses
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> parentheses = new Stack<char>();

            foreach (char symbol in input)
            {
                if (parentheses.Any())
                {
                    if (parentheses.Peek() == '(' && symbol == ')')
                    {
                        parentheses.Pop();
                        continue;
                    }

                    else if (parentheses.Peek() == '{' && symbol == '}')
                    {
                        parentheses.Pop();
                        continue;
                    }

                    else if (parentheses.Peek() == '[' && symbol == ']')
                    {
                        parentheses.Pop();
                        continue;
                    }
                }
                parentheses.Push(symbol);
            }

            Console.WriteLine(!parentheses.Any() ? "YES" : "NO");
        }
    }
}
