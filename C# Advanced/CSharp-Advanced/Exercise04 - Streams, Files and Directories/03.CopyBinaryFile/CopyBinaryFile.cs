using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream image = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[image.Length];
                image.Read(buffer);

                using (FileStream copy = new FileStream(outputFilePath, FileMode.Create))
                {
                    copy.Write(buffer);
                }
            }
        }
    }
}
