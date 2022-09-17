using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    internal class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int operationsNum = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> prevVersions = new Stack<string>();
            string previousVersion = text.ToString();

            for (int op = 0; op < operationsNum; op++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdArgs[0];

                if (cmd == "1")
                {
                    string textToAppend = cmdArgs[1];

                    previousVersion = text.ToString();
                    prevVersions.Push(previousVersion);
                    text.Append(textToAppend);
                }

                else if (cmd == "2")
                {
                    int count = int.Parse(cmdArgs[1]);
                    int startIndex = text.Length - count;

                    previousVersion = text.ToString();
                    prevVersions.Push(previousVersion);
                    text = text.Remove(startIndex, count);
                }

                else if (cmd == "3")
                {
                    int index = int.Parse(cmdArgs[1]);
                    Console.WriteLine(text[index - 1]);
                }

                else if (cmd == "4")
                {
                    text = new StringBuilder(prevVersions.Pop());
                }
            }
        }
    }
}
