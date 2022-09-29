using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = File.ReadAllLines(inputFilePath);

            for (int lineNum = 1; lineNum <= lines.Length; lineNum++)
            {
                int lettersCounter = lines[lineNum - 1].Count(x => char.IsLetter(x));
                int punctuationCount = lines[lineNum - 1].Count(x => char.IsPunctuation(x));

                sb.AppendLine($"Line {lineNum}: {lines[lineNum - 1]} ({lettersCounter})({punctuationCount})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
