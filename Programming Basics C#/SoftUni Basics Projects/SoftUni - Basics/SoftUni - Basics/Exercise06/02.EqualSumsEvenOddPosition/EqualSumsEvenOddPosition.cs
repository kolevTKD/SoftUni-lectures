using System;

namespace _02.EqualSumsEvenOddPosition
{
    class EqualSumsEvenOddPosition
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                string currentNum = i.ToString();
                int evenSum = 0;
                int oddSum = 0;
                for (int lengthCheck = 0; lengthCheck < currentNum.Length; lengthCheck++)
                {
                    int currentDigit = int.Parse(currentNum[lengthCheck].ToString());
                    if (lengthCheck % 2 == 0)
                    {
                        evenSum += currentDigit;
                    }
                    else
                    {
                        oddSum += currentDigit;
                    }
                }
                if (evenSum == oddSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
