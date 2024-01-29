using System.Text;
using System.Globalization;

namespace Task1Lib
{
    public static class FileHandler
    {
        private static string OpenAndReadFile(string fileName)
        {
            var data = File.ReadAllText(fileName);
            return data;
        }

        private static void CreateAndWriteResultsInFile(IEnumerable<(string Word, double Frequency, double Percent)> results, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var stream = File.Create(fileName))
            {
                var encoding = Encoding.UTF8;

                var numberFormatInfo = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = "."
                };

                var writer = new StreamWriter(stream, encoding);

                foreach (var result in results)
                {
                    writer.WriteLine($"{result.Word.ToString(numberFormatInfo)}, " +
                                     $"{result.Frequency.ToString(numberFormatInfo)}, " +
                                     $"{result.Percent.ToString(numberFormatInfo)}");
                }

                ;
                writer.Close();
            }
        }

        private static string GetOutputFileNameWithExtension(string fileName, string ext) =>
            Path.GetFileNameWithoutExtension(fileName) + "_analyze." + $"{ext}";
    }
}
