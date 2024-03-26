using Common.TasksLibrary.Models;

namespace PracticeTests
{
    [TestFixture("word", 0.05, 5)]
    internal class WordWithPercentTests
    {
        private const string Expected = "word, 0.05, 5";
        private WordWithPercent _word;

        public WordWithPercentTests(string word, double frequency, double percent)
        {
            _word = new WordWithPercent(word, frequency, percent);
        }

        [Test]
        public void Test_TestToStringMethod()
        {
            var result = _word.ToString();
            Assert.AreEqual(Expected, result);
        }
    }
}