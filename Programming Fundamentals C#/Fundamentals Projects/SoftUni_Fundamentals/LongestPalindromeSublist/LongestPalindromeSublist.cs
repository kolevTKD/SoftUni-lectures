using System;

namespace LongestPalindromeSublist
{
    class LongestPalindromeSublist
    {
        static void Main(string[] args)
        {
            string inputList = Console.ReadLine();
            int maxLength = 0;

            for (int singleLetter = 0; singleLetter < inputList.Length; singleLetter++)
            {
                maxLength = Math.Max(maxLength, PalindromeLength(singleLetter, singleLetter, inputList));
            }

            for (int doubleLetter = 0; doubleLetter < inputList.Length; doubleLetter++)
            {
                maxLength = Math.Max(maxLength, PalindromeLength(doubleLetter, doubleLetter + 1, inputList));
            }

            Console.WriteLine(maxLength);
        }

        static int PalindromeLength(int leftIndex, int rightIndex, string inputList)
        {
            while (leftIndex >= 0 && rightIndex < inputList.Length 
                && inputList[leftIndex] == inputList[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }

            return rightIndex - leftIndex - 1;
        }
    }
}
