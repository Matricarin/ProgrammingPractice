namespace Task1Lib
{
    public class Analyzer
    {
        //initial commit
        private Dictionary<string, int> _dict;

        private double _amountOfWords;

        public Analyzer()
        {
            _dict = new Dictionary<string, int>();
            _amountOfWords = 0;
        }

        public void AddWord(string word)
        {
            if (!_dict.ContainsKey(word))
            {
                _dict.Add(word, 1);
            }
            else
            {
                _dict[word]++;
            }

            _amountOfWords++;
        }

        public IEnumerable<(string, double, double)> GetWordsFrequency()
        {
            _dict.OrderBy(w => w.Key);

            List<(string, double, double)> result = new List<(string, double, double)>();

            foreach (var word in _dict)
            {
                var freq = word.Value / _amountOfWords;
                result.Add((word.Key, freq, freq * 100));
            }

            return result;
        }
    }
}
