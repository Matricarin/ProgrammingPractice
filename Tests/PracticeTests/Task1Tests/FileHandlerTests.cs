using Common.TasksLibrary.Task1;

namespace PracticeTests.Task1Tests;
[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class FileHandlerTests
{
   [Test]
   public void OpenAndReadFile()
   {
      var testFile = new FileInfo(Path.Combine(Environment.CurrentDirectory, 
         "TestingData","Task1_FileHandlerTest_OpenAndRead.txt"));
      
      var readContentInFile = "Hello from file!";
      
      var handler = new FileHandler(testFile);
      
      var result =handler.OpenAndReadFile();
      
      Assert.That(result, Is.EqualTo(readContentInFile));
   }
   
   [Test]
   public void CreateHandlerWithException()
   {
      var expected = new Exception("Please provide a file.");
      try
      {
         var handler = new FileHandler(null);
      }
      catch (Exception e)
      {
         Assert.That(expected.Message, Is.EqualTo(e.Message));
      }
   }
}

