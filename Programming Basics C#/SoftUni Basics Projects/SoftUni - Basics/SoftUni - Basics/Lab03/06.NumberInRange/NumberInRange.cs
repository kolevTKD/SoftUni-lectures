using System;

namespace _06.NumberInRange
{
    class NumberInRange
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool isGreater = number >= -100;
            bool isLess = number <= 100;
            bool isEqual = number == 0;

            if (isGreater && isLess && !isEqual)
            {
                Console.WriteLine("Yes");
            }

            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
