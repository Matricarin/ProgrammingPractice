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

                    var sb = new StringBuilder();

                    while (reader.EndOfStream)
                    {
                        encoding = reader.CurrentEncoding;

                        var ch = Convert.ToChar(reader.Read());

                        if (!Char.IsLetterOrDigit(ch))
                        {
                            analyzer.AddWord(sb.ToString());
                            sb.Clear();
                        }
                        else
                        {
                            sb.Append(ch);
                        }
                        
                    }
                    reader.Close();
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
//читаем построчно файл

//файл должен быть формата txt, иначе выкидываем исключение

//каждую строку читаем посимвольно, чтобы собирать слова,
//исключая пробелы и знаки препинания

//переводим все в нижний регистр

//слово заносим в словарь текстового файла

//записываем итоговую коллекцию в файл сsv

//сохраняем файл в место, где лежит исходный текстовый файл
//имя_файла_analyze.csv