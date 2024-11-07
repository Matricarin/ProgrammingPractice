using System.Collections;
using Common.TasksLibrary.Models;
using Common.TasksLibrary.Task1;

namespace PracticeTests;

[TestFixtureSource(typeof(FileHandlerTestsData), nameof(FileHandlerTestsData.FixtureParams))]
internal class FileHandlerTests
{
    private readonly string DirectoryPath = Environment.CurrentDirectory;
    private FileInfo FileForTest;
    private List<WordWithPercent> DataForCsv;

    public FileHandlerTests(string fileForTest)
    {
        FileForTest = new FileInfo(Path.Combine(DirectoryPath, fileForTest));
    }

    public FileHandlerTests(List<WordWithPercent> list)
    {
        DataForCsv = list;
    }

    [Test]
    public void Test_OpenAndReadFile_ReadsCorrectContent()
    {
        var text = FileHandler.OpenAndReadFile(FileForTest);

        var expected = "Hello, World!" + $"{Environment.NewLine}" +
                       "Hello, World!" + $"{Environment.NewLine}" +
                       "Hello, World!" + $"{Environment.NewLine}" +
                       "Hello, World!" + $"{Environment.NewLine}" +
                       "Hello, World!" + $"{Environment.NewLine}" +
                       "Hello, World!";

        Assert.AreEqual(expected, text, "File content does not match the expected text.");
    }

    [Test]
    public void Test_CreateAndWriteResultsInCsvFile_WritesCorrectly()
    {
        FileHandler.CreateAndWriteResultsInCsvFile(DataForCsv);

        Assert.IsTrue(File.Exists(_csvTestFilePath), "CSV file was not created.");

        var csvContent = File.ReadAllText(_csvTestFilePath, Encoding.UTF8);
        var expectedContent = "Hello,50\nWorld,50\n";
        Assert.AreEqual(expectedContent, csvContent, "CSV content does not match expected output.");
    }
}

public class FileHandlerTestsData
{
    public static IEnumerable FixtureParams
    {
        get
        {
            yield return new TestFixtureData("FileHandlerTestFile.txt");
            yield return new TestFixtureData(new List<WordWithPercent>
            {
                new WordWithPercent("Hello", 0.5, 50),
                new WordWithPercent("World", 0.5, 50)
            });
        }
    }
}