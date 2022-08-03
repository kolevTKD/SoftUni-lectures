using System;
using System.Linq;
using System.Text;

namespace _01._5.Messages
{
    class Messages
    {
        static void Main(string[] args)
        {
            int messageLength = int.Parse(Console.ReadLine());
            char a = 'a';
            StringBuilder message = new StringBuilder();

            for (int currLetter = 1; currLetter <= messageLength; currLetter++)
            {
                string letterDigits = Console.ReadLine();
                int numberOfDigits = letterDigits.Length;
                int mainDigit = int.Parse(letterDigits.Substring(0, 1));

                if (mainDigit == 0)
                {
                    message.Append(" ");
                    continue;
                }
                int offsetNumber = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offsetNumber += 1;
                }

                int letterIndex = offsetNumber + numberOfDigits - 1;
                message.Append((char)(a + letterIndex));
            }

            Console.WriteLine(message);
        }
    }
}
