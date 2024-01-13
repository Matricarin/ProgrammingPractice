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
            List<(string Word, double Frequency, double Percent)> result = 
                new List<(string Word, double Frequency, double Percent)>();

            foreach (var word in _dictionaryOfWordsWithQuantity)
            {
                var frequency = Math.Round(word.Value / _amountOfWords, 2);
                result.Add((word.Key, frequency, frequency * 100));
            }

            return result.OrderByDescending(w => w.Frequency);
        }
    }
}
