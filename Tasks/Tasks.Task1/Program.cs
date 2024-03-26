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
                var text = FileHandler.OpenAndReadFile(fileName);

                var resultAnalysis = WordFrequencyAnalyzer.GetAnalyzeSourceTextResults(text);

                FileHandler.CreateAndWriteResultsInFile(resultAnalysis, "");

                Console.WriteLine("Complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}