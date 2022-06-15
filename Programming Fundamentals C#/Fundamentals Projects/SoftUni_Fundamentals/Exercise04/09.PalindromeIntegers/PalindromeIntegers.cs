using System;

namespace _09.PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string end = "END";
            string command = Console.ReadLine();

            while (command != end)
            {
                int number = int.Parse(command);
                int palindrome = PalindromeNumber(number);
                bool isPalindrome = number == palindrome;

                // Console.WriteLine(isPalindrome.ToString().ToLower());
                Console.WriteLine(isPalindrome ? "true" : "false");
                command = Console.ReadLine();
            }
        }

        static int PalindromeNumber(int number)
        {
            int palindromeNum = 0;
            while (number != 0)
            {
                int currentDigit = number % 10;
                palindromeNum = palindromeNum * 10 + currentDigit;
                number /= 10;
            }

            return palindromeNum;
        }
    }
}
