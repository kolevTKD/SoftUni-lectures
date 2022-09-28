using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            int counter = 0;
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = string.Empty;

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (counter % 2 == 0)
                    {
                        string replacedLine = ReplacePunctuation(line);
                        string reversedLine = ReverseLine(replacedLine);
                        sb.AppendLine(reversedLine);
                    }

                    counter++;
                }

                return sb.ToString();
            }
        }

        static string ReplacePunctuation(string line)
        {
            foreach (char ch in line)
            {
                if (char.IsPunctuation(ch))
                {
                    line = line.Replace(ch, '@');
                }
            }

            return line;
        }

        static string ReverseLine(string line)
        {
            string[] reversed = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return string.Join(' ', reversed);
        }
    }
}

