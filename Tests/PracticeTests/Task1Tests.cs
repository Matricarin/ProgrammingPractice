using Task1Lib;

namespace PracticeTests
{
    public class Task1Tests
    {
        private readonly Analyzer _analyzer = new();


        [SetUp]
        public void Setup()
        {
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

        [Test]
        public void Test_GetWordsFrequency_method_first_value()
        {
            var first = _analyzer.GetWordsFrequency().First();
            Assert.True(first.Word == "one" 
                        && Math.Abs(first.Frequency - 1 / 2.0) < 0.001 
                        && Math.Abs(first.Percent - 1 / 2.0 * 100) < 0.001);
        }

        [Test]
        public void Test_GetWordsFrequency_method_third_value()
        {
            var list = _analyzer.GetWordsFrequency();

            var expected = new List<(string, double, double)>()
            {
                ("one", 0.5, 50),
                ("three", 1 / 6.0, 1 / 6.0 * 100),
                ("two", 1 / 3.0, 1 / 3.0 * 100)
            };

            Assert.That(list, Is.EquivalentTo(expected));
        }
    }
}