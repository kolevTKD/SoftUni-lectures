using System;

namespace _05_Login
{
    class Login
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string pass = null;
            string passInput = null;
            int password = username.Length;
            int passInputs = 0;

            for(int currentDigit = password; currentDigit >= 1; currentDigit--)
            {
                pass += username[currentDigit - 1];
            }

            while(passInput != pass)
            {
                passInput = Console.ReadLine();
                passInputs++;

                if(passInput == pass)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }

                else if(passInputs == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                else if(passInput != pass)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    continue;
                }
            }
        }
    }
}
