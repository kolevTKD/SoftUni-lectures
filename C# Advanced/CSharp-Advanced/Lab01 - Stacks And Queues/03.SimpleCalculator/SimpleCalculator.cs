using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    internal class SimpleCalculator
    {
        static void Main(string[] args)
        {
            Stack<string> elements = new Stack<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray());

            while (elements.Count > 1)
            {
                int num1 = int.Parse(elements.Pop());
                string symbol = elements.Pop();
                int num2 = int.Parse(elements.Pop());
                int result = 0;

                if (symbol == "+")
                {
                    result = num1 + num2;
                }

                else if (symbol == "-")
                {
                    result = num1 - num2;
                }

                elements.Push(result.ToString());
            }
            Console.WriteLine(elements.Pop());
        }
    }
}
