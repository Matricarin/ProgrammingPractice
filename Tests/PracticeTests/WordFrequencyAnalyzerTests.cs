using System.Reflection;
using Common.TasksLibrary.Task1;

namespace PracticeTests
{
    [TestFixture]
    internal class WordFrequencyAnalyzerTests
    {
        //private readonly Analyzer _analyzer = new();


        //[SetUp]
        //public void Setup()
        //{
        //    _analyzer.AddWord("one");
        //    _analyzer.AddWord("one");
        //    _analyzer.AddWord("one");
        //    _analyzer.AddWord("two");
        //    _analyzer.AddWord("three");
        //    _analyzer.AddWord("two");
        //}

        //[Test]
        //public void Test_AddWord_method_has_value()
        //{
        //    var analyzer = new Analyzer();
        //    analyzer.AddWord("test");
        //    Assert.True(analyzer.GetWordsFrequency().Any());
        //}

        //[Test]
        //public void Test_AddWord_method_has_not_value()
        //{
        //    var analyzer = new Analyzer();
        //    Assert.False(analyzer.GetWordsFrequency().Any());
        //}

        //[Test]
        //public void Test_GetWordsFrequency_method_first_value()
        //{
        //    var first = _analyzer.GetWordsFrequency().First();
        //    Assert.True(first.Word == "one" 
        //                && Math.Abs(first.Frequency - 1 / 2.0) < 0.001 
        //                && Math.Abs(first.Percent - 1 / 2.0 * 100) < 0.001);
        //}

        //[Test]
        //public void Test_GetWordsFrequency_method_check_multiple_values()
        //{
        //    var list = _analyzer.GetWordsFrequency();

        //    var expected = new List<(string, double, double)>()
        //    {
        //        ("one",  Math.Round(1 / 2.0, 2),  Math.Round(1 / 2.0, 2) * 100),
        //        ("two",  Math.Round(1 / 3.0, 2),  Math.Round(1 / 3.0, 2) * 100),
        //        ("three",  Math.Round(1 / 6.0, 2),  Math.Round(1 / 6.0, 2) * 100)
        //    };

        //    CollectionAssert.AreEqual(expected, list);
        //}

        //[Test]
        //public void Test_GetWordsIntoAnalyzerFromText_method()
        //{
        //    const string text = "test test, test, test \n test";

        //    const int expected = 5;

        //    var myAnalyzer = new Analyzer();

        //    myAnalyzer.GetWordsIntoAnalyzerFromText(text);

        //    Assert.True(expected == myAnalyzer.AmountOfWords);
        //}

        //[Test]
        //public void Test_GetOutputFileNameWithExtension_method()
        //{
        //    const string expected = "TestName_analyze.txt";
        //    var result = FileHandler.GetOutputFileNameWithExtension("TestName", "txt");
        //    Assert.True(expected == result);
        //}

        //[Test]
        //public void Test_CreateAndWriteResultsInFile()
        //{
        //    var myAnalyzer = new Analyzer();

        //    myAnalyzer.GetWordsIntoAnalyzerFromText(Properties.Resources.Task1Test4Source);

        //    var content = myAnalyzer.GetWordsFrequency();

        //    FileHandler.CreateAndWriteResultsInFile(content, "result");

        //    Assert.True(File.Exists("result"));
        //}
    }
}