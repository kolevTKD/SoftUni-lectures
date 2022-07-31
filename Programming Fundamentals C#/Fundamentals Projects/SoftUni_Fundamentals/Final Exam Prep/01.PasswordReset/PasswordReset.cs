using System;
using System.Text;

namespace _01.PasswordReset
{
    class PasswordReset
    {
        static void Main(string[] args)
        {
            string rawPassword = Console.ReadLine();
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = commands[0];
            string end = "Done";
            StringBuilder newPassword = new StringBuilder();

            while (command != end)
            {
                switch (command)
                {
                    case "TakeOdd":
                        for (int index = 1; index < rawPassword.Length; index++)
                        {
                            if (index % 2 == 1)
                            {
                                newPassword.Append(rawPassword[index]);
                            }
                        }
                        rawPassword = newPassword.ToString();
                        Console.WriteLine(rawPassword);

                        break;

                    case "Cut":
                        int startIndex = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);
                        rawPassword = rawPassword.Remove(startIndex, length);
                        Console.WriteLine(rawPassword);

                        break;

                    case "Substitute":
                        string substring = commands[1];
                        string substitute = commands[2];

                        if (rawPassword.Contains(substring))
                        {
                            rawPassword = rawPassword.Replace(substring, substitute);
                            Console.WriteLine(rawPassword);
                        }

                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        break;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                command = commands[0];
            }

            Console.WriteLine($"Your password is: {rawPassword}");
        }
    }
}
