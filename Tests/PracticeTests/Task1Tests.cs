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

        [Test]
        public void Test_GetWordsFrequency_method_first_value()
        {
            var first = _analyzer.GetWordsFrequency().First();
            Assert.True(first.Item1 == "one" && first.Item2 == (double)1/2 &&
                        first.Item3 == (double)1/2 * 100);
        }

        [Test]
        public void Test_GetWordsFrequency_method_third_value()
        {
            var list = new List<(string, double, double)>();
            foreach (var valueTuple in _analyzer.GetWordsFrequency())
            {
                list.Add(valueTuple);
            }
            var third = list[3];
            Assert.True(third.Item1 == "three" && third.Item2 == (double)1/6 &&
                        third.Item3 == (double)1/6 * 100);
        }
    }
}