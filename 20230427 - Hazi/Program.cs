using System;
using System.IO;

namespace Hazi
{
    internal class Program
    {
        static void Main()
        {
            string directoryPath = @"D:\alma";

            string fileExtension = ".txt";

            DateTime creationDate = DateTime.Parse("2023.04.20 00:00:00");

            string[] allFilesWithSelectedExtension = Directory.GetFiles(directoryPath, "*" + fileExtension, SearchOption.AllDirectories);

            string[] matchingFiles = Array.FindAll(allFilesWithSelectedExtension, file => File.GetCreationTime(file) >= creationDate);

            using (StreamWriter writer = new StreamWriter(@"D:/files.txt"))
            {
                foreach (string file in matchingFiles)
                {
                    writer.WriteLine(file);
                }
            }
        }
    }
}
