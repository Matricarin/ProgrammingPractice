using System.Globalization;
using System.Text;

namespace Common.TasksLibrary.Task1
{
    public static class FileHandler
    {
        public static string OpenAndReadFile(string fileName)
        {
            var data = File.ReadAllText(fileName);
            return data;
        }

        public static void CreateAndWriteResultsInFile(IEnumerable<(string Word, double Frequency, double Percent)> results, string fileName)
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

        public static string GetOutputFileNameWithExtension(string fileName, string ext) =>
            Path.GetFileNameWithoutExtension(fileName) + "_analyze." + $"{ext}";
    }
}
