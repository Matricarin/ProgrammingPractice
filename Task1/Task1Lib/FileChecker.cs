namespace Task1Lib
{
    public static class FileChecker
    {
        public static FileInfo CheckFiles(string file)
        {
            if (file.Length == 0)
            {
                throw new Exception("File names are not entered.");
            }

            if (!File.Exists(file))
            {
                throw new Exception("The file was not found.");
            }
        }
    }
}
