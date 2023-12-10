using Task1Lib;

using System.Text;

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

                System.Text.Encoding encoding;

                using (var stream = File.OpenRead(args[0]))
                {
                    var reader = new StreamReader(stream);
                    
                    encoding = reader.CurrentEncoding;

                    var sb = new StringBuilder();

                    while (true)
                    {
                        var ch = Convert.ToChar(reader.Read());

                        if (Char.IsLetterOrDigit(ch))
                        {
                            var s = ch.ToString().ToLower();
                            sb.Append(char.Parse(s));
                        }
                        else
                        {
                            analyzer.AddWord(sb.ToString());
                            sb.Clear();
                        }

                        if (reader.EndOfStream)
                        {
                            break;
                        }
                        
                    }
                    reader.Close();
                }

                var resultAnalysis = analyzer.GetWordsFrequency();

                var resultFileName = args[0].Substring(0, args[0].IndexOf('.')) + "_analyze.csv";

                if (File.Exists(resultFileName))
                {
                    File.Delete(resultFileName);
                }

                using (var stream = File.Create(resultFileName))
                {
                    var writer = new StreamWriter(stream, encoding);

                    foreach (var result in resultAnalysis)
                    {
                        writer.WriteLine($"{result.Item1}, {result.Item2}, {result.Item3}");
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