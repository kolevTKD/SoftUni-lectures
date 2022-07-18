using System;

namespace _03.ExtractFile
{
    class ExtractFile
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine().Split('\\');
            string[] fileName = filePath[filePath.Length - 1].Split('.');
            string name = fileName[0];
            string extension = fileName[1];

            Console.WriteLine($"File name: {name} \nFile extension: {extension}");
        }
    }
}
