using System;

namespace _08.NumberSequence
{
    class NumberSequence
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;

            for (int i = 0; i < a; i++)
            {
                int newNum = int.Parse(Console.ReadLine());

                if (newNum > maxNumber)
                {
                    maxNumber = newNum;
                }

                if (newNum < minNumber)
                {
                    minNumber = newNum;
                }
            }

            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
