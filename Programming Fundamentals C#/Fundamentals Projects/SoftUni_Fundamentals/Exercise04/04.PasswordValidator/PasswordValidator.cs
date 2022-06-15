using System;

namespace _04.PasswordValidator
{
    class PasswordValidator
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValid = true;
            bool passLength = CharsNum(password);
            bool passSymbols = LettersAndDigits(password);
            bool passDigits = DigitCount(password);

            if (!passLength)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (!passSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (!passDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool CharsNum(string password)
        {
            bool isValid = true;
            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
            }
            return isValid;
        }

        static bool LettersAndDigits(string password)
        {
            bool isValid = true;
            for (int index = 0; index < password.Length; index++)
            {
                if (!char.IsLetterOrDigit(password[index]))
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        static bool DigitCount(string password)
        {
            bool isValid = true;
            int digitCounter = 0;

            for (int index = 0; index < password.Length; index++)
            {
                if (char.IsDigit(password[index]))
                {
                    digitCounter++;
                }
            }

            if (digitCounter < 2)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
