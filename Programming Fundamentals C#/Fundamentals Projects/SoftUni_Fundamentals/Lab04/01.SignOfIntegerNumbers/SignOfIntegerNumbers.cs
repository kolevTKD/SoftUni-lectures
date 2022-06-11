using System;

namespace _01.SignOfIntegerNumbers
{
    class SignOfIntegerNumbers
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            NumberType(inputNumber);
        }

        static void NumberType(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }

            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }

            else
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
    }
}
