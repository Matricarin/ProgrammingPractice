using Common.TasksLibrary.Task1;

namespace PracticeTests.Task1Tests;
[TestFixture]
public class WordFrequencyAnalyzerTest
{
    [TestCaseSource(typeof(WordFrequencyTestData), nameof(WordFrequencyTestData.TestData))]
    public void GetAnalyzeSourceTextResultsMethod_Test(string text, IEnumerable<WordWithPercent> expected)
    {
        var result = WordFrequencyAnalyzer.GetAnalyzeSourceTextResults(text).ToList();
        var expectedList = expected.ToList();
        CollectionAssert.AreEqual(result, expectedList);
    }
    
    [TestCaseSource(typeof(WordFrequencyTestData), nameof(WordFrequencyTestData.ExceptionTestData))]
    public void GetExceptionFromAnalyzingSourceTextResultsMethod_Test(string text, Exception expected)
    {
        try
        {
            var result = WordFrequencyAnalyzer.GetAnalyzeSourceTextResults(text);
        }
        catch (Exception e)
        {
            Assert.That(expected.Message, Is.EqualTo(e.Message));
        }
    }
}

public class WordFrequencyTestData
{
    public static object[] TestData = new[]
    {
        new object[]{"Hello, file, file, file", new List<WordWithPercent>()
        {
            new WordWithPercent("file", 0.75, 75),
            new WordWithPercent("Hello", 0.25, 25)
        }}
    };

    public static object[] ExceptionTestData = new[]
    {
        new object[]{string.Empty, new Exception("WordFrequencyAnalyzer received an empty string or null.")}
    };
}