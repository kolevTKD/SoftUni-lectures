using System;
using System.Text;

namespace _01.ActivationKeys
{
    class ActivationKeys
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();
            string end = "Generate";


            while (true)
            {
                string[] commands = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == end)
                {
                    break;
                }

                switch (command)
                {
                    case "Contains":
                        string substring = commands[1];

                        if (rawActivationKey.Contains(substring))
                        {
                            Console.WriteLine($"{rawActivationKey} contains {substring}");
                        }

                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }

                        continue;

                    case "Flip":
                        string upperLower = commands[1];
                        int startIndex = int.Parse(commands[2]);
                        int endIndex = int.Parse(commands[3]);
                        int substringLength = endIndex - startIndex;
                        StringBuilder changedSubstring = new StringBuilder();

                        if (upperLower == "Upper")
                        {
                            for (int start = startIndex; start < endIndex; start++)
                            {
                                changedSubstring.Append(char.ToUpper(rawActivationKey[start]));
                            }
                        }

                        else if (upperLower == "Lower")
                        {
                            for (int start = startIndex; start < endIndex; start++)
                            {
                                changedSubstring.Append(char.ToLower(rawActivationKey[start]));
                            }
                        }

                        rawActivationKey = rawActivationKey.Remove(startIndex, substringLength);
                        rawActivationKey = rawActivationKey.Insert(startIndex, changedSubstring.ToString());

                        break;

                    case "Slice":
                        int startI = int.Parse(commands[1]);
                        int endI = int.Parse(commands[2]);
                        int count = endI - startI;
                        rawActivationKey = rawActivationKey.Remove(startI, count);

                        break;
                }

                Console.WriteLine(rawActivationKey);
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}
