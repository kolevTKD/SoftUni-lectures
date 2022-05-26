using System;

namespace _03.EvenOrOdd
{
    class EvenOrOdd
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool divider = number % 2 == 0;
            if (divider)
            {
                Console.WriteLine("even");
            }

            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
