using System.Text;

namespace Task1Lib
{
    public class Analyzer
    {
        private double _amountOfWords = 0;

        private readonly Dictionary<string, int> _dictionaryOfWordsWithQuantity = new();

        private readonly StringBuilder _stringBuilder = new();

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

        public void GetWordsIntoAnalyzerFromText(string text)
        {
            foreach (var ch in text)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    _stringBuilder.Append(ch);
                }
                else if (ch == '\n')
                {
                    continue;
                }
                else
                {
                    this.AddWord(_stringBuilder.ToString());
                    _stringBuilder.Clear();
                }
            }

            if (_stringBuilder.ToString() != string.Empty ||
                _stringBuilder.ToString() != "")
            {
                this.AddWord(_stringBuilder.ToString());
            }
        }

        public IEnumerable<(string Word, double Frequency, double Percent)> GetWordsFrequency()
        {
            var result = new List<(string Word, double Frequency, double Percent)>();

            foreach (var word in _dictionaryOfWordsWithQuantity)
            {
                var frequency = Math.Round(word.Value / _amountOfWords, 2);
                result.Add((word.Key, frequency, frequency * 100));
            }

            return result.OrderByDescending(w => w.Frequency);
        }
    }
}
