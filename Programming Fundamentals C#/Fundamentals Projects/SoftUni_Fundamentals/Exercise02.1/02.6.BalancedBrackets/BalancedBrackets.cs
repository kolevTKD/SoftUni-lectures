using System;

namespace _02._6.BalancedBrackets
{
    class BalancedBrackets
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            bool isOpened = false;
            bool isBalanced = true;

            for (int line = 1; line <= linesCount; line++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    if (isOpened)
                    {
                        isBalanced = false;
                        break;
                    }
                    isOpened = true;
                }

                else if (input == ")")
                {
                    if (isOpened)
                    {
                        isOpened = false;
                        continue;
                    }

                    isBalanced = false;
                }
            }

            if (isOpened)
            {
                isBalanced = false;
            }

            Console.WriteLine(isBalanced ? "BALANCED" : "UNBALANCED");
        }
    }
}
