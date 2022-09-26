using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream image = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream part1 = new FileStream(partOneFilePath, FileMode.Create))
                {
                    int odd = image.Length % 2 == 1 ? 1 : 0;
                    byte[] part1Buffer = new byte[image.Length / 2 + odd];
                    image.Read(part1Buffer);
                    part1.Write(part1Buffer);

                }

                using (FileStream part2 = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] part2Buffer = new byte[image.Length / 2];
                    image.Read(part2Buffer);
                    part2.Write(part2Buffer);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream joined = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (FileStream part1 = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] part1Buffer = new byte[part1.Length];
                    part1.Read(part1Buffer);
                    joined.Write(part1Buffer);
                }

                using (FileStream part2 = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] part2Buffer = new byte[part2.Length];
                    part2.Read(part2Buffer);
                    joined.Write(part2Buffer);
                }
            }
        }
    }
}

