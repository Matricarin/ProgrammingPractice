using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task1;

namespace PracticeTests.ExtensionsTests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class EnumerableExtensionsTests
{
    [Test]
    public void CreateAndWriteCsvFile()
    {
        const string contentInResultFile = "Hello, 0.1, 10\r\nfile, 0.9, 90\r\n";
        
        var testWords = new List<WordWithPercent>()
        {
           new WordWithPercent("Hello", 0.1),
           new WordWithPercent("file", 0.9)
        };
        
       testWords.CreateAndWriteResultsInCsvFile();
       
       var content = File.ReadAllText(StringConstants.ResultCsvFileName);
       
       Assert.That(content, Is.EqualTo(contentInResultFile));
    }
}