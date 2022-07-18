using System;
using System.Collections.Generic;

namespace _01.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<string> validUsernames = new List<string>();

            foreach (string username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool isValidUsername = true;

                    for (int index = 0; index < username.Length; index++)
                    {
                        char currentChar = username[index];

                        if (!(currentChar == '-' || currentChar == '_' || char.IsLetterOrDigit(currentChar)))
                        {
                            isValidUsername = false;
                            break;
                        }
                    }

                    if (isValidUsername)
                    {
                        validUsernames.Add(username);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }
    }
}
