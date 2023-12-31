﻿namespace Task1Lib
{
    public static class FileChecker
    {
        public static void CheckFiles(string file)
        {
            if (file.Length == 0)
            {
                throw new Exception("File names are not entered.");
            }

            var format = file.Contains(".txt");
            if (!format)
            {
                throw new Exception($"Unsupported file format: {file}");
            }

            if (!File.Exists(file))
            {
                throw new Exception("The file was not found.");
            }
        }
    }
}
