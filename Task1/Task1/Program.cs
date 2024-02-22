using Task1Lib;

namespace Task1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var fileName = args[0];

            try
            {
                var analyzer = new Analyzer();

                var text = FileHandler.OpenAndReadFile(fileName);

                analyzer.GetWordsIntoAnalyzerFromText(text);

                var resultAnalysis = analyzer.GetWordsFrequency();

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