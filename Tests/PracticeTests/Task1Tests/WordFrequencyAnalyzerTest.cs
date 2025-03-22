using Common.TasksLibrary.Task1;

namespace PracticeTests.Task1Tests;
[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class WordFrequencyAnalyzerTest
{
    [TestCaseSource(typeof(WordFrequencyTestData), nameof(WordFrequencyTestData.TestData))]
    public void GetAnalyzeSourceTextResults(string text, IEnumerable<WordWithPercent> expected)
    {
        var analyzer = new WordFrequencyAnalyzer(text);
        var result = analyzer.GetWordsFrequency();
        var expectedList = expected.ToList();
        CollectionAssert.AreEqual(result, expectedList);
    }
    
    [TestCaseSource(typeof(WordFrequencyTestData), nameof(WordFrequencyTestData.ExceptionTestData))]
    public void GetExceptionFromAnalyzingSourceTextResults(string text, Exception expected)
    {
        try
        {
            var analyzer = new WordFrequencyAnalyzer(text);
            var result = analyzer.GetWordsFrequency();
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
            new WordWithPercent("file", 0.75),
            new WordWithPercent("Hello", 0.25)
        }}
    };
    
    public static object[] ExceptionTestData = new[]
    {
        new object[]{string.Empty, new Exception("WordFrequencyAnalyzer received an empty string or null.")}
    };
}