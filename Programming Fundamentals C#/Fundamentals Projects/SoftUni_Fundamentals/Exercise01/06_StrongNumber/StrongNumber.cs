using System;

namespace _06_StrongNumber
{
    class StrongNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string numString = number.ToString();
            int numberCopy = number;
            int numLength = numString.Length;
            int sum = 0;

            for (int currentNum = 1; currentNum <= numLength; currentNum++)
            {
                int currentSum = 1;
                int currentDigit = numberCopy % 10;
                numberCopy /= 10;

                for (int fact = currentDigit; fact >= 2; fact--)
                {
                    currentSum *= fact;
                }

                sum += currentSum;
            }
            Console.WriteLine(sum == number ? "yes" : "no");
        }
    }
}
