using System;
using System.Linq;

namespace _01.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string end = "Complete";

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == end)
                {
                    break;
                }

                if (command == "Make")
                {
                    int charIndex = int.Parse(commands[2]);
                    string letter = password[charIndex].ToString();
                    password = password.Remove(charIndex, 1);

                    if (commands[1] == "Upper")
                    {
                        password = password.Insert(charIndex, letter.ToUpper());
                    }

                    else if (commands[1] == "Lower")
                    {
                        password = password.Insert(charIndex, letter.ToLower());

                    }
                }

                else if (command == "Insert")
                {
                    int insIndex = int.Parse(commands[1]);
                    string toInsert = commands[2];

                    if (insIndex >= 0 && insIndex < password.Length)
                    {
                        password = password.Insert(insIndex, toInsert);
                    }
                }

                else if (command == "Replace")
                {
                    char symbol = char.Parse(commands[1]);
                    int value = int.Parse(commands[2]);

                    if (password.Contains(symbol))
                    {
                        char toReplace = (char)(symbol + value);
                        password = password.Replace(symbol, toReplace);
                    }
                }

                else if (command == "Validation")
                {
                    bool isUpper = false;
                    bool isLower = false;
                    bool hasDigit = false;

                    if (password.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (!(char.IsLetterOrDigit(password[i]) && password[i] != '_'))
                        {
                            Console.WriteLine("Password must consist only of letters, digits and _!");
                            break;
                        }
                    }

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (char.IsUpper(password[i]))
                        {
                            isUpper = true;
                            break;
                        }
                    }

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (char.IsLower(password[i]))
                        {
                            isLower = true;
                            break;
                        }
                    }

                    if (!isUpper)
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }

                    if (!isLower)
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (char.IsDigit(password[i]))
                        {
                            hasDigit = true;
                            break;
                        }
                    }

                    if (!hasDigit)
                    {
                        Console.WriteLine("Password must consist at least one digit!");
                    }

                    continue;
                }

                else
                {
                    continue;
                }

                Console.WriteLine(password);
            }
        }
    }
}
