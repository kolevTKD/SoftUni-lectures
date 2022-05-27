using System;

namespace _05.PrintPartOfASCIITable
{
    class PrintPartOfASCIITable
    {
        static void Main(string[] args)
        {
            int beginning = int.Parse(Console.ReadLine());
            int ending = int.Parse(Console.ReadLine());

            for (int currentDigit = beginning; currentDigit <= ending; currentDigit++)
            {
                Console.Write($"{(char)currentDigit} ");
            }
            
        }
    }
}
