using System.Collections;
using System.Reflection;
using Common.TasksLibrary.Task1;

namespace PracticeTests
{
    [TestFixtureSource(typeof(FileHandlerTestsData))]
    internal class FileHandlerTests
    {
        private static readonly string? _directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private FileInfo FileForTest { get; set; }

        public FileHandlerTests(string resourcePath)
        {
            FileForTest = new FileInfo(_directoryPath + resourcePath);
        }

        [Test]
        public void Test_ReadAndOpenFile_method_txt()
        {
            var text = FileHandler.OpenAndReadFile(FileForTest);

            const string expected = "Hello, World!\n" +
                                    "Hello, World!\n" +
                                    "Hello, World!\n" +
                                    "Hello, World!\n" +
                                    "Hello, World!\n" +
                                    "Hello, World!";

            Assert.True(expected == text);
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
