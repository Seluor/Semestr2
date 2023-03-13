/****************
 * Imamov Roman *
 * PI-221       *
 * Lab 4        *
 ***************/

using System;
using System.IO;

namespace Lab_4 {
    internal class Program {
        static void Main(string [] args) {
            Console.Write("Enter folder path: ");
            string UserPath = @"C:\";
            bool Success = false;
            while (Success == false) {
                UserPath = Console.ReadLine();
                if (Directory.Exists(UserPath) && UserPath != string.Empty) {
                    Success = true;
                }
                else {
                    Console.WriteLine("Incorrect path. Try again");
                }
            }
            int Choice = 0;
            while (Choice != 4) {
                Console.Clear();
                Console.WriteLine($"File manager\n{UserPath}");
                Console.WriteLine("1. Edit file 1\n2. Find files by keywords 2\n" +
                    "3. Index files in folder to file 3\n4. Exit");
                while (Choice < 1 || Choice > 4) {
                    if (int.TryParse(Convert.ToString(Console.ReadLine()), out Choice) == false) {
                        Console.WriteLine("Incorrect data entered. Try again");
                    }
                }
                Console.Clear();
                string FileName;
                switch (Choice) {
                    case 1:
                    Console.Clear();
                    Console.Write("Enter name txt file to edit: ");
                    FileName = Console.ReadLine();
                    Editor.InitiateEdit(UserPath + @"\" + FileName + ".txt", FileName);
                    Choice = 0;
                    break;
                    case 2:
                    Console.Write("Enter keywords to search: ");
                    string UserKeywords = Console.ReadLine();
                    Console.Clear();
                    Searcher.KeywordsFilesSearcher(UserPath, UserKeywords);
                    Console.ReadKey();
                    Choice = 0;
                    break;
                    case 3:
                    Indexator.PerformIndexation(UserPath);
                    Choice = 0;
                    break;
                }
            }
        }
    }
}