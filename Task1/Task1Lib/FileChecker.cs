namespace Task1Lib
{
    public static class FileChecker
    {
        public static void CheckFiles(string[] files)
        {
            if (files.Length == 0)
            {
                throw new Exception("File names are not entered.");
            }

            foreach (string file in files)
            {
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
}
