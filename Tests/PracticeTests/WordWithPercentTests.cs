using Common.TasksLibrary.Models;

namespace PracticeTests
{
    [TestFixture]
    internal class WordWithPercentTests
    {
        [Test]
        public void Test_TestToStringMethod()
        {
            string word = "word";
            double frequency = 0.05;
            double percent = 5;
            string expected = "word, 0.05, 5";

            WordWithPercent wordWithPercent = new WordWithPercent(word, frequency, percent);
            string result = wordWithPercent.ToString();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}