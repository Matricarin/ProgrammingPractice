using System.Collections;
using System.Reflection;
using System.Text;
using Common.TasksLibrary.Models;
using Common.TasksLibrary.Task1;

namespace PracticeTests
{
    [TestFixtureSource(typeof(FileHandlerTestsData))]
    internal class FileHandlerTests
    {
        private static readonly string? DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private FileInfo _testFile;
        private string _csvTestFilePath;
        
        public FileHandlerTests(string resourcePath)
        {
            _testFile = new FileInfo(Path.Combine(DirectoryPath, resourcePath));
            _csvTestFilePath = Path.Combine(DirectoryPath, "result.csv");
        }

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_csvTestFilePath))
            {
                File.Delete(_csvTestFilePath);
            }
        }

        [TearDown]
        public void Teardown()
        {
            if (File.Exists(_csvTestFilePath))
            {
                File.Delete(_csvTestFilePath);
            }
        }

        [Test]
        public void Test_ReadAndOpenFile_ReadsCorrectContent()
        {
            var text = FileHandler.OpenAndReadFile(_testFile);
            
            string expected = "Hello, World!" + $"{Environment.NewLine}" +
                              "Hello, World!" + $"{Environment.NewLine}" +
                              "Hello, World!" + $"{Environment.NewLine}" +
                              "Hello, World!" + $"{Environment.NewLine}" +
                              "Hello, World!" + $"{Environment.NewLine}" +
                                    "Hello, World!";

            Assert.AreEqual(expected, text, "File content does not match the expected text.");
        }

        [Test]
        public void Test_CreateAndWriteResltsInCsvFile_WritesCorrectly()
        {
            var results = new List<WordWithPercent>
            {
                new WordWithPercent("Hello", 0.5, 50),
                new WordWithPercent("World", 0.5, 50),
            };

            FileHandler.CreateAndWriteResultsInCsvFile(results);

            Assert.IsTrue(File.Exists(_csvTestFilePath), "CSV file was not created");

            var csvContent = File.ReadAllText(_csvTestFilePath, Encoding.UTF8);
            var expectedContent = "Hello, 0.5, 50" + $"{Environment.NewLine}" + 
                                  "World, 0.5, 50" + $"{Environment.NewLine}";
            Assert.AreEqual(expectedContent, csvContent, "CSV content does not match expected output");
        }
    }

    internal class FileHandlerTestsData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]{ "\\Resources\\Task1Test1.txt"};
            yield return new object[] { "\\Resources\\Task1Test2.md" };
            yield return new object[] { "\\Resources\\Task1Test3.doc" };
        }
    }
}
