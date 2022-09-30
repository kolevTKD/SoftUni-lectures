using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);

            SortedDictionary<string, List<FileInfo>> extensions = new SortedDictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!extensions.ContainsKey(fileInfo.Extension))
                {
                    extensions.Add(fileInfo.Extension, new List<FileInfo>());
                }

                extensions[fileInfo.Extension].Add(fileInfo);
            }

            var orderedExtensions = extensions.OrderByDescending(c => c.Value.Count);

            StringBuilder extensionsLines = new StringBuilder();

            foreach (var extension in orderedExtensions)
            {
                extensionsLines.AppendLine($"{extension.Key}");
                var orderedFiles = extension.Value.OrderBy(f => f.Length / 1024);

                foreach (var file in orderedFiles)
                {
                    extensionsLines.AppendLine($"--{file.Name}{file.Extension} - {(double)file.Length}kb");
                }
            }

            return extensionsLines.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(desktopPath, textContent);
        }
    }
}

