using System;

namespace _05.SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            for (int i = 1; i <= range; i++)
            {
                int sum = 0;
                int currentNum = i;
                bool isSpecial = false;

                while (currentNum != 0)
                {
                    sum += currentNum % 10;

                    currentNum /= 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isSpecial = true;
                    Console.WriteLine($"{i} -> {isSpecial}");
                }

                else
                {
                    Console.WriteLine($"{i} -> {isSpecial}");
                }
            }
        }
    }
}
