using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader readerInput1 = new StreamReader(firstInputFilePath);
            string[] input1 = File.ReadAllLines(firstInputFilePath);

            using (readerInput1)
            {
                StreamReader readerInput2 = new StreamReader(secondInputFilePath);
                string[] input2 = File.ReadAllLines(secondInputFilePath);

                using (readerInput2)
                {
                    StreamWriter writer = new StreamWriter(outputFilePath);

                    using (writer)
                    {
                        string[] shorter = input1.Length < input2.Length ? input1 : input2;
                        string[] longer = input1.Length < input2.Length ? input2 : input1;
                        int diff = longer.Length - shorter.Length;

                        for (int index = 0; index < longer.Length; index++)
                        {
                            if (index >= shorter.Length)
                            {
                                writer.WriteLine(longer[index]);
                                continue;
                            }

                            writer.WriteLine($"{input1[index]}\n{input2[index]}");
                        }
                    }
                }
            }
        }
    }
}

