using Task1Lib;

using System.Text;
using System.Globalization;

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

                var text = OpenAndReadFile(fileName);

                analyzer.GetWordsIntoAnalyzerFromText(text);

                var resultAnalysis = analyzer.GetWordsFrequency();

                var resultFileName = GetOutputFileName(fileName);

                if (File.Exists(resultFileName))
                {
                    File.Delete(resultFileName);
                }

                using (var stream = File.Create(resultFileName))
                {
                    var encoding = Encoding.UTF8;

                    var numberFormatInfo = new NumberFormatInfo()
                    {
                        NumberDecimalSeparator = "."
                    };

                    var writer = new StreamWriter(stream, encoding);

                    foreach (var result in resultAnalysis)
                    {
                        writer.WriteLine($"{result.Word.ToString(numberFormatInfo)}, " +
                                         $"{result.Frequency.ToString(numberFormatInfo)}, " +
                                         $"{result.Percent.ToString(numberFormatInfo)}");
                    };
                    writer.Close();
                }

                Console.WriteLine("Complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static string OpenAndReadFile(string fileName)
        {
            var data = File.ReadAllText(fileName);
            return data;
        }
        
        private static string WriteResultsInCsvFile(IEnumerable<(string Word, double Frequency, double Percent)> results, string fileName)
        {
            return string.Empty;
        }

        private static string GetOutputFileName(string fileName) =>
            fileName.Substring(0, fileName.IndexOf('.')) + "_analyze.csv";
    }
}