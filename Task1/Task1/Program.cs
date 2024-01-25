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

                var stringBuilder = new StringBuilder();

                var info = new FileInfo(fileName);

                var fileLength = info.Length;

                var data = new byte[fileLength];

                using (var stream = File.OpenRead(fileName))
                {
                    var bytesRead = 0;
                    var size = 1;
                    while (bytesRead < fileLength && size > 0)
                    {
                        size = stream.Read(data, bytesRead, data.Length - bytesRead);
                        bytesRead += size;
                    }
                }

                var text = Encoding.UTF8.GetString(data);
                
                foreach (var ch in text)
                {
                    if (char.IsLetterOrDigit(ch))
                    {
                        stringBuilder.Append(ch);
                    }
                    else if (ch == '\n')
                    {
                        continue;
                    }
                    else
                    {
                        analyzer.AddWord(stringBuilder.ToString());
                        stringBuilder.Clear();
                    }
                }

                if (stringBuilder.ToString() != string.Empty ||
                    stringBuilder.ToString() != "")
                {
                    analyzer.AddWord(stringBuilder.ToString());
                }

                var resultAnalysis = analyzer.GetWordsFrequency();

                var resultFileName = fileName.Substring(0, fileName.IndexOf('.')) + "_analyze.csv";

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
    }
}