using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string zipArchiveFilePath = @"..\..\..\archive.zip";
            string outputFilePath = @"..\..\..\extracted.png";
            string fileName = Path.GetFileName(inputFilePath);

            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
            ExtractFileFromArchive(zipArchiveFilePath, fileName, outputFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            if (File.Exists(zipArchiveFilePath))
            {
                File.Delete(zipArchiveFilePath);
            }

            using (ZipArchive archiver = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            {
                string fileName = Path.GetFileName(inputFilePath);

                archiver.CreateEntryFromFile(inputFilePath, fileName);
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (ZipArchive extracter = ZipFile.OpenRead(zipArchiveFilePath))
            {
                ZipArchiveEntry entry = extracter.GetEntry(fileName);

                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }

                entry.ExtractToFile(outputFilePath);
            }
        }
    }
}

