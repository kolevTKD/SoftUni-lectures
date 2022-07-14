using System;

namespace _07.SafePassGen
{
    class SafePasswordsGenerator
    {
        static void Main(string[] args)
        {
            int numA = int.Parse(Console.ReadLine());
            int numB = int.Parse(Console.ReadLine());
            int maxPassNum = int.Parse(Console.ReadLine());
            int passCounter = 0;
            char a = '\u0023';
            char b = '\u0040';

            for (int numX = 1; numX <= numA; numX++)
            {
                for (int numY = 1; numY <= numB; numY++)
                {
                    Console.Write($"{a}{b}{numX}{numY}{b}{a}|");

                    a++;
                    if (a > '\u0037')
                    {
                        a = '\u0023';
                    }

                    b++;

                    if (b > '\u0060')
                    {
                        b = '\u0040';
                    }

                    passCounter++;

                    if (numX == numA && numY == numB)
                    {
                        return;
                    }

                    else if (passCounter >= maxPassNum)
                    {
                        return;
                    }
                }
            }
        }
    }
}
