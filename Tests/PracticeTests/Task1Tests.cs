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
        public void Test_GetWordsFrequency_method_check_multiple_values()
        {
            var list = _analyzer.GetWordsFrequency();

            var expected = new List<(string, double, double)>()
            {
                ("one",  Math.Round(1 / 2.0, 2), Math.Round(1 / 2.0, 2) * 100),
                ("two", Math.Round(1 / 3.0, 2), Math.Round(1 / 3.0, 2) * 100),
                ("three", Math.Round(1 / 6.0, 2), Math.Round(1 / 6.0, 2) * 100)
            };

            CollectionAssert.AreEqual(expected, list);
        }
    }
}