using System;
using System.Linq;
using System.Text;

namespace _01.SecterChat
{
    class SecretChat
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();
            string end = "Reveal";

            while (true)
            {
                string[] commands = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == end)
                {
                    break;
                }

                switch (command)
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);
                        concealedMessage = concealedMessage.Insert(index, " ");

                        break;

                    case "Reverse":
                        string substringToReverse = commands[1];

                        if (concealedMessage.Contains(substringToReverse))
                        {
                            StringBuilder reversed = new StringBuilder();

                            for (int i = substringToReverse.Length - 1; i >= 0; i--)
                            {
                                reversed.Append(substringToReverse[i]);
                            }

                            int substringIndex = concealedMessage.IndexOf(substringToReverse);
                            concealedMessage = concealedMessage.Remove(substringIndex, substringToReverse.Length);
                            concealedMessage = concealedMessage.Insert(concealedMessage.Length, reversed.ToString());
                        }

                        else
                        {
                            Console.WriteLine("error");
                            continue;
                        }

                        break;

                    case "ChangeAll":
                        string substringToReplace = commands[1];
                        string replacement = commands[2];

                        if (concealedMessage.Contains(substringToReplace))
                        {
                            concealedMessage = concealedMessage.Replace(substringToReplace, replacement);
                        }

                        break;
                }

                Console.WriteLine(concealedMessage);

            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}
