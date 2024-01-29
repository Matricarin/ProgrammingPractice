using Task1Lib;

using System.Reflection;

namespace PracticeTests
{
    public class Task1Tests
    {
        private readonly Analyzer _analyzer = new();


        [SetUp]
        public void Setup()
        {
            _analyzer.AddWord("one");
            _analyzer.AddWord("one");
            _analyzer.AddWord("one");
            _analyzer.AddWord("two");
            _analyzer.AddWord("three");
            _analyzer.AddWord("two");
        }

        [Test]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Test]
        public void Test_AddWord_method_has_value()
        {
            var analyzer = new Analyzer();
            analyzer.AddWord("test");
            Assert.True(analyzer.GetWordsFrequency().Any());
        }

        [Test]
        public void Test_AddWord_method_has_not_value()
        {
            var analyzer = new Analyzer();
            Assert.False(analyzer.GetWordsFrequency().Any());
        }

        [Test]
        public void Test_GetWordsFrequency_method_first_value()
        {
            var first = _analyzer.GetWordsFrequency().First();
            Assert.True(first.Word == "one" 
                        && Math.Abs(first.Frequency - 1 / 2.0) < 0.001 
                        && Math.Abs(first.Percent - 1 / 2.0 * 100) < 0.001);
        }

        [Test]
        public void Test_GetWordsFrequency_method_check_multiple_values()
        {
            var list = _analyzer.GetWordsFrequency();

            var expected = new List<(string, double, double)>()
            {
                ("one",  Math.Round(1 / 2.0, 2),  Math.Round(1 / 2.0, 2) * 100),
                ("two",  Math.Round(1 / 3.0, 2),  Math.Round(1 / 3.0, 2) * 100),
                ("three",  Math.Round(1 / 6.0, 2),  Math.Round(1 / 6.0, 2) * 100)
            };

            CollectionAssert.AreEqual(expected, list);
        }

        [Test]
        public void Test_GetWordsIntoAnalyzerFromText_method()
        {
            const string text = "test test, test, test \n test";

            const int expected = 5;

            var myAnalyzer = new Analyzer();

            myAnalyzer.GetWordsIntoAnalyzerFromText(text);

            Assert.True(expected == myAnalyzer.AmountOfWords);
        }

        [Test]
        public void Test_ReadAndOpenFile_method_txt()
        {
            var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var filePath = Path.Combine(directoryPath + "\\Resources\\Task1Test1.txt");

            var text = FileHandler.OpenAndReadFile(filePath);
            
            var expected = "Hello, World!\r\n" +
                           "Hello, World!\r\n" +
                           "Hello, World!\r\n" +
                           "Hello, World!\r\n" +
                           "Hello, World!\r\n" +
                           "Hello, World!";

            Assert.True(expected == text);
        }

        [Test]
        public void Test_ReadAndOpenFile_method_md()
        {
            var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var filePath = Path.Combine(directoryPath + "\\Resources\\Task1Test2.md");

            var text = FileHandler.OpenAndReadFile(filePath);

            var expected = "Hello, World!\n" +
                           "Hello, World!\n" +
                           "Hello, World!\n" +
                           "Hello, World!\n" +
                           "Hello, World!\n" +
                           "Hello, World!";

            Assert.False(expected == text);
        }

        [Test]
        public void Test_ReadAndOpenFile_method_doc()
        {
            var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var filePath = Path.Combine(directoryPath + "\\Resources\\Task1Test3.doc");

            var text = FileHandler.OpenAndReadFile(filePath);

            var expected = "Hello, World!\n" +
                           "Hello, World!\n" +
                           "Hello, World!\n" +
                           "Hello, World!\n" +
                           "Hello, World!\n" +
                           "Hello, World!";

            Assert.False(expected == text);
        }

        [Test]
        public void Test_GetOutputFileNameWithExtension_method()
        {

        }
    }
}