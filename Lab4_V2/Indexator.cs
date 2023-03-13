using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_4 {
    internal static class Indexator {
        public static void PerformIndexation(string Path) {
            List<string> extensions = new List<string>();
            Console.WriteLine("Enter the extensions you would like to index. To stop type '~'");
            while (!extensions.Contains("~")) {
                extensions.Add(Console.ReadLine());
            }
            extensions.Remove("~");

            Console.Write("\nEnter a filename with extension: ");
            string loggingFileName = Path + @"\" + Console.ReadLine();
            FileStream indexatedFile = new FileStream(loggingFileName, FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(indexatedFile))
                foreach (string currentExtension in extensions) {
                    var extensionFiles = Directory.EnumerateFiles(Path, "*." + currentExtension,
                        SearchOption.AllDirectories);
                    writer.WriteLine(currentExtension + ":\n");
                    foreach (string currentFile in extensionFiles) {
                        string fileName = currentFile.Substring(Path.Length);
                        writer.WriteLine(fileName);
                    }
                }
            indexatedFile.Close();
        }
    }
}