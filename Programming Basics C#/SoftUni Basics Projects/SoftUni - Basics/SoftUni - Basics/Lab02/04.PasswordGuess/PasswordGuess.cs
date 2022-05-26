using System;

namespace _04.PasswordGuess
{
    class PasswordGuess
    {
        static void Main(string[] args)
        {
            string passwordInput = Console.ReadLine();
            string password = "s3cr3t!P@ssw0rd";

            bool passCheck = passwordInput == password;

            if (passCheck)
            {
                Console.WriteLine("Welcome");

            }

            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
