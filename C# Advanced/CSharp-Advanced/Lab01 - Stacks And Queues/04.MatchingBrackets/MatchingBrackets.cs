using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    internal class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> indices = new Stack<int>();

            for (int index = 0; index < expression.Length; index++)
            {
                if (expression[index] == '(')
                {
                    indices.Push(index);
                }

                else if (expression[index] == ')')
                {
                    int startIndex = indices.Pop();
                    string bracesContent = expression.Substring(startIndex, index - startIndex + 1);
                    Console.WriteLine(bracesContent);
                }
            }
        }
    }
}
