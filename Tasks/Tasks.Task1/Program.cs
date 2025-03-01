using Common.TasksLibrary.Extensions;
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
                var handler = new FileHandler(fileInfo);

                var text = handler.OpenAndReadFile();
                
                var analayzer = new WordFrequencyAnalyzer(text);
            
                var resultAnalysis = analayzer.GetWordsFrequency();
            
                resultAnalysis.CreateAndWriteResultsInCsvFile();
            
                Console.WriteLine("Complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}