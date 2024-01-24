using Task1Lib;

using System.Text;
using System.Globalization;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var analyzer = new Analyzer();

                var stringBuilder = new StringBuilder();

                var info = new FileInfo(args[0]);

                var fileLength = info.Length;

                var data = new byte[fileLength];

                using (var stream = File.OpenRead(args[0]))
                {
                    int bytesRead = 0;
                    int size = 1;
                    while (bytesRead < fileLength && size > 0)
                    {
                        size = stream.Read(data, bytesRead, data.Length - bytesRead);
                        bytesRead += size;
                    }
                }

                var text = Encoding.UTF8.GetString(data);
                
                foreach (var ch in text)
                {
                    if (Char.IsLetterOrDigit(ch))
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

                var resultFileName = args[0].Substring(0, args[0].IndexOf('.')) + "_analyze.csv";

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