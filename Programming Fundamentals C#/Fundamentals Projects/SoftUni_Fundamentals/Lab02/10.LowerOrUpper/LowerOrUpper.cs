using System;

namespace _10.LowerOrUpper
{
    class LowerOrUpper
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());
            string symbolString = symbol.ToString();

            if (symbolString == symbolString.ToUpper())
            {
                Console.WriteLine("upper-case");
            }

            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
