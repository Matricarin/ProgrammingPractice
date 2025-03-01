using System.Diagnostics.Contracts;
using Common.TasksLibrary.Extensions;

namespace Common.TasksLibrary.Task1
{
    public sealed class FileHandler
    {
        private readonly FileInfo _fileInfo;
        
        public FileHandler(FileInfo fileInfo)
        {
            if (fileInfo.IsNull())
            {
                throw new NullReferenceException("Please provide a file.");
            }
            
            _fileInfo = fileInfo;
        }
        
        [Pure]
        public string OpenAndReadFile()
        {
            var data = File.ReadAllText(_fileInfo.FullName);
            return data;
        }
    }
}
