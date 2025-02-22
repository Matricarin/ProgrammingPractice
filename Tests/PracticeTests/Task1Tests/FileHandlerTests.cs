using Common.TasksLibrary;
using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task1;

namespace PracticeTests.Task1Tests;
[TestFixture]
public class FileHandlerTests
{
   private FileInfo _testFile;
   private string _readContentInFile;
   private List<WordWithPercent> _testWords;
   private string _contentInResultFile;
   [SetUp]
   public void Setup()
   {
      _testFile = new FileInfo(Path.Combine(Environment.CurrentDirectory, 
         "TestingData","Task1_FileHandlerTest_OpenAndRead.txt"));
      _readContentInFile = "Hello from file!";
      _testWords = new List<WordWithPercent>()
      {
         new WordWithPercent("Hello", 0.1, 10),
         new WordWithPercent("file", 0.9, 90)
      };
      _contentInResultFile = "Hello, 0.1, 10\r\nfile, 0.9, 90\r\n";
   }

   [Test]
   public void OpenAndReadFile()
   {
      var result = FileHandler.OpenAndReadFile(_testFile);
      Assert.That(result, Is.EqualTo(_readContentInFile));
   }

   [Test]
   public void CreateAndWriteCsvFile()
   {
      FileHandler.CreateAndWriteResultsInCsvFile(_testWords);
      var content = File.ReadAllText(StringConstants.ResultCsvFileName);
      Assert.That(content, Is.EqualTo(_contentInResultFile));
   }
}

