using System;

namespace _01.TheImitationGame
{
    class TheImitationGame
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string end = "Decode";

            while (true)
            {
                string[] commands = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == end)
                {
                    break;
                }

                string command = commands[0];

                switch (command)
                {
                    case "Move":
                        int numOfLetters = int.Parse(commands[1]);

                        if (numOfLetters < encryptedMessage.Length)
                        {
                            string substring = encryptedMessage.Substring(0, numOfLetters);
                            encryptedMessage = encryptedMessage.Remove(0, numOfLetters);
                            encryptedMessage = encryptedMessage.Insert(encryptedMessage.Length, substring);
                        }

                        break;

                    case "Insert":
                        int index = int.Parse(commands[1]);
                        string value = commands[2];

                        if (index >= 0 && index <= encryptedMessage.Length)
                        {
                            encryptedMessage = encryptedMessage.Insert(index, value);
                        }

                        break;

                    case "ChangeAll":
                        string currentText = commands[1];
                        string replacement = commands[2];

                        if (encryptedMessage.Contains(currentText))
                        {
                            encryptedMessage = encryptedMessage.Replace(currentText, replacement);
                        }

                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
