using Task1Lib;

namespace PracticeTests
{
    public class Tests
    {
        private Analyzer _analyzer;

        [SetUp]
        public void Setup()
        {
            _analyzer = new Analyzer();
            _analyzer.AddWord("one");
            _analyzer.AddWord("one");
            _analyzer.AddWord("one");
            _analyzer.AddWord("two");
            _analyzer.AddWord("three");
            _analyzer.AddWord("two");
        }

        [Test]
        public void FirstTest()
        {
            Assert.True(true);
        }
    }
}