using System;

namespace _01._2.EnglishNameOfLastDigit
{
    class EnglishNameOfLastDigit
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            NameOfDigit(number);
        }

        static void NameOfDigit(int number)
        {
            int lastDigit = number % 10;
            string digitAsWord = string.Empty;

            switch (lastDigit)
            {
                case 0:
                    digitAsWord = "zero";
                    break;
                case 1:
                    digitAsWord = "one";
                    break;
                case 2:
                    digitAsWord = "two";
                    break;
                case 3:
                    digitAsWord = "three";
                    break;
                case 4:
                    digitAsWord = "four";
                    break;
                case 5:
                    digitAsWord = "five";
                    break;
                case 6:
                    digitAsWord = "six";
                    break;
                case 7:
                    digitAsWord = "seven";
                    break;
                case 8:
                    digitAsWord = "eight";
                    break;
                case 9:
                    digitAsWord = "nine";
                    break;
            }
            Console.WriteLine(digitAsWord);
            return;
        }
    }
}
