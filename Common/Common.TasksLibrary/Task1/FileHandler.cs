using System.Text;

namespace Common.TasksLibrary.Task1
{
    public static class FileHandler
    {
        public static string OpenAndReadFile(FileInfo fileInfo)
        {
            var data = File.ReadAllText(fileInfo.FullName);
            return data;
        }

        public static void CreateAndWriteResultsInCsvFile(IEnumerable<WordWithPercent> results)
        {
            using (var stream = File.Create(Constants.ResultCsvFileName))
            {
                var encoding = Encoding.UTF8;
                
                var writer = new StreamWriter(stream, encoding);

                foreach (var result in results)
                {
                    writer.WriteLine(result.ToString());
                }

                writer.Close();
            }
        }
    }
}
