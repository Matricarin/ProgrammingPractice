namespace Task1Lib
{
    public class FileChecker
    {
        private string[] _files;

        public FileChecker(string[] args)
        {
            _files = args;
            CheckFiles(_files);
        }

        private void CheckFiles(string[] files)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
