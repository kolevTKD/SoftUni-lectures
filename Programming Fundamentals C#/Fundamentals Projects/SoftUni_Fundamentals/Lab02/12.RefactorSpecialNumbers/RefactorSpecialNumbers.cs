using System;

namespace _12.RefactorSpecialNumbers
{
    class RefactorSpecialNumbers
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = 0;
            bool isSpecialNum = false;
            for (int currentNum = 1; currentNum <= count; currentNum++)
            {
                number = currentNum;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum = currentNum / 10;
                }
                isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", number, isSpecialNum);
                sum = 0;
                currentNum = number;
            }
        }
    }
}
