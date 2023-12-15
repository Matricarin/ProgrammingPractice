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
                FileChecker.CheckFiles(args[0]);

                var analyzer = new Analyzer();

                var sb = new StringBuilder();

                FileInfo info = new FileInfo(args[0]);

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
                        sb.Append(ch);
                    }
                    else if (ch == '\n')
                    {
                        continue;
                    }
                    else
                    {
                        analyzer.AddWord(sb.ToString());
                        sb.Clear();
                    }
                }

                if (sb.ToString() != string.Empty ||
                    sb.ToString() != "")
                {
                    analyzer.AddWord(sb.ToString());
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
                        writer.WriteLine($"{result.Item1.ToString(numberFormatInfo)}, " +
                                         $"{result.Item2.ToString(numberFormatInfo)}, " +
                                         $"{result.Item3.ToString(numberFormatInfo)}");
                    };
                    writer.Close();
                }

                Console.WriteLine("Complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}