using Common.TasksLibrary.Task1;

namespace Tasks.Task1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var fileName = args[0];

            try
            {
                var analyzer = new WordFrequencyAnalyzer();

                var text = FileHandler.OpenAndReadFile(fileName);

                var resultAnalysis = analyzer.GetAnalyzeSourceTextResults(text);

                var resultFileName = FileHandler.GetOutputFileNameWithExtension(fileName, "csv");

                FileHandler.CreateAndWriteResultsInFile(resultAnalysis, resultFileName);

                Console.WriteLine("Complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}