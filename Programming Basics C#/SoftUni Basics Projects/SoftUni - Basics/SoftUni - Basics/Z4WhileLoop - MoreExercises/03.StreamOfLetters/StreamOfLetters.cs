using System;

namespace _03.StreamOfLetters
{
    class StreamOfLetters
    {
        static void Main(string[] args)
        {
            string input = null;
            string word = null;
            string newWord = null;
            string end = "End";
            char c = 'c';
            char o = 'o';
            char n = 'n';
            int cCounter = 0;
            int oCounter = 0;
            int nCounter = 0;
            int symbolCounter = 0;


            while (input != end)
            {
                if (symbolCounter == 3)
                {
                    cCounter = 0;
                    oCounter = 0;
                    nCounter = 0;
                    symbolCounter = 0;
                    word += ' ';
                    newWord += word;
                    word = null;
                    continue;
                }

                input = Console.ReadLine();

                if (input == end)
                {
                    break;
                }

                char symbol = char.Parse(input);
                bool isLetter = char.IsLetter(symbol);

                if (!isLetter)
                {
                    continue;
                }

                if (symbol == c)
                {
                    cCounter++;

                    if (cCounter <= 1)
                    {
                        symbolCounter++;
                        continue;
                    }
                }

                else if (symbol == o)
                {
                    oCounter++;

                    if (oCounter <= 1)
                    {
                        symbolCounter++;
                        continue;
                    }
                }

                else if (symbol == n)
                {
                    nCounter++;

                    if (nCounter <= 1)
                    {
                        symbolCounter++;
                        continue;
                    }
                }

                word += symbol;
            }
            Console.WriteLine($"{newWord}");
        }
    }
}
