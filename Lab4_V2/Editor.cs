using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_4 {
    internal static class Editor {
        public static void InitiateEdit(string UserPath, string FileName) {
            Console.Write("What would you like to do with the specified file?\n\n1. Edit the text\n" +
                "2. Save the state\n3. Roll back changes\n\nEnter the option number: ");
            int Choice = 0;
            while (Choice < 1 || Choice > 3) {
                if (int.TryParse(Convert.ToString(Console.ReadLine()), out Choice) == false) {
                    Console.WriteLine("Invalid input. Please try again");
                }
            }

            FileStream file = new FileStream(UserPath, FileMode.OpenOrCreate);
            switch (Choice) {
                case 1:
                FileReader(file, FileName);
                Console.Clear();
                Console.WriteLine("Enter the new file content (press ~ to exit):");
                char ch;
                int element;
                string Input = "";
                do {
                    element = Console.Read();
                    try {
                        ch = Convert.ToChar(element);
                        Input += ch;
                    }
                    catch (OverflowException) {
                        Console.WriteLine($"{element} - invalid value");
                        ch = Char.MinValue;
                    }
                } while (ch != '~');
                FileWriter(Input, UserPath, FileName);
                Console.Clear();
                Console.WriteLine("Changes added successfully");
                Console.ReadKey();
                break;
                case 2:
                FileReader(file, FileName);
                ct.SaveState(textFile);
                break;
                case 3:
                try {
                    file.Close();
                    RestoreData(UserPath, FileName);
                }
                catch (KeyNotFoundException) {
                    Console.WriteLine("There were no changes");
                    Console.ReadKey();
                }
                break;
            }
            file.Close();
        }

        static TextClass textFile = new TextClass();
        static Caretaker ct = new Caretaker();

        private static void FileReader(FileStream file, string FileName) {
            string outString = "";
            var reader = new StreamReader(file);

            while (!reader.EndOfStream) {
                outString += reader.ReadLine();
            }
            try {
                textFile.Content.Add(FileName, outString);
                textFile.FileName.Add(FileName);
            }
            catch (Exception) {
                textFile.Content [FileName] = outString;
            }
            reader.Close();
        }

        private static void FileWriter(string input, string UserPath, string FileName) {
            using (StreamWriter writer = new StreamWriter(UserPath, true)) {
                writer.Write(input);
            }
        }

        private static void RestoreData(string UserPath, string FileName) {
            ct.RestoreState(textFile);
            using (StreamWriter writer = new StreamWriter(UserPath, false)) {
                writer.Write(textFile.Content [FileName]);
            }
        }
    }
}
