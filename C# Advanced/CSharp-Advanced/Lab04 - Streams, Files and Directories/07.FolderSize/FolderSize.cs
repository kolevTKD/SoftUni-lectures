using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double size = ReccursiveIteration(folderPath);
            size = size / 1024 / 1024;

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(size);
            }
        }

        private static double ReccursiveIteration(string folderPath)
        {
            double size = 0;

            string[] dir = Directory.GetDirectories(folderPath);
            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files)
            {
                size += file.Length;
            }

            foreach (string directory in dir)
            {
                ReccursiveIteration(directory);
                size += directory.Length;
            }

            return size;
        }
    }
}
