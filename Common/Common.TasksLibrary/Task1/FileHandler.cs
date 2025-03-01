namespace Common.TasksLibrary.Task1
{
    public class FileHandler
    {
        private FileInfo _fileInfo;
        public FileHandler(FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                throw new NullReferenceException("Please provide a file.");
            }
            
            _fileInfo = fileInfo;
        }
        public string OpenAndReadFile()
        {
            var data = File.ReadAllText(_fileInfo.FullName);
            return data;
        }
    }
}
