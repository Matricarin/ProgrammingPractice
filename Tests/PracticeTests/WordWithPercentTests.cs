using Common.TasksLibrary.Models;

namespace PracticeTests
{
    [TestFixture]
    public class WordWithPercentTests
    {
        private WordWithPercent _word;
        
        [SetUp]
        public void Setup()
        {
            _word = new WordWithPercent("word", 0.05, 5);
        }

        [Test]
        public void Test_TestToStringMethod()
        {
            var result = _word.ToString();
            Assert.Equals("word, 0.05, 5", result);
        }

    }
}