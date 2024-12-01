using Common.TasksLibrary.Task1;

namespace Tasks.Task1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var fileInfo = new FileInfo(args.First());

            try
            {
                var text = FileHandler.OpenAndReadFile(fileInfo);

                var resultAnalysis = WordFrequencyAnalyzer.GetAnalyzeSourceTextResults(text);

                FileHandler.CreateAndWriteResultsInCsvFile(resultAnalysis);

                Console.WriteLine("Complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}