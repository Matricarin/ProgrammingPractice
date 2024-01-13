namespace Task1Lib
{
    public class Analyzer
    {
        private Dictionary<string, int> _dictionaryOfWordsWithQuantity;

        private double _amountOfWords;

        public Analyzer()
        {
            _dictionaryOfWordsWithQuantity = new Dictionary<string, int>();
            _amountOfWords = 0;
        }

        public void AddWord(string word)
        {
            if (!_dictionaryOfWordsWithQuantity.ContainsKey(word))
            {
                _dictionaryOfWordsWithQuantity.Add(word, 1);
            }
            else
            {
                _dictionaryOfWordsWithQuantity[word]++;
            }

            _amountOfWords++;
        }

        public IEnumerable<(string Word, double Frequency, double Percent)> GetWordsFrequency()
        {
            _dictionaryOfWordsWithQuantity.OrderBy(w => w.Key);

            List<(string, double, double)> result = new List<(string, double, double)>();

            foreach (var word in _dictionaryOfWordsWithQuantity)
            {
                var frequency = word.Value / _amountOfWords;
                result.Add((word.Key, frequency, frequency * 100));
            }

            return result;
        }
    }
}
