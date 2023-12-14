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

                string text = string.Empty;

                using (var stream = File.OpenRead(args[0]))
                {
                    byte[] bytes = new byte[stream.Length];

                    stream.Read(bytes, 0, bytes.Length);
                    
                    text = Encoding.UTF8.GetString(bytes);
                }

                foreach (var ch in text)
                {
                    if (Char.IsLetterOrDigit(ch))
                    {
                        sb.Append(ch);
                    }
                    else
                    {
                        analyzer.AddWord(sb.ToString());
                        sb.Clear();
                    }
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