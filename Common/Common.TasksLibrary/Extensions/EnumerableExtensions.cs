using System.Text;
using Common.TasksLibrary.Task1;

namespace Common.TasksLibrary.Extensions;

public static class EnumerableExtensions
{
    public static void CreateAndWriteResultsInCsvFile(this IEnumerable<WordWithPercent> results)
    {
        using (var stream = File.Create(Constants.StringConstants.ResultCsvFileName))
        {
            var encoding = Encoding.UTF8;
            
            using (var writer = new StreamWriter(stream, encoding))
            {
                foreach (var result in results)
                {
                    writer.WriteLine(result.ToString());
                }

                writer.Close();
            }
        }
    }
}