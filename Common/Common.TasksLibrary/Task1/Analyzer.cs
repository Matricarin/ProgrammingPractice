using System.Text;
using Common.TasksLibrary.Models;

namespace Common.TasksLibrary.Task1
{
    public class WordFrequencyAnalyzer : IAnalyzer<WordWithPercent>
    {
        public int AmountOfWords { get; private set; } = 0;

        private readonly Dictionary<string, int> _dictionaryOfWordsWithQuantity = new();

        private readonly StringBuilder _stringBuilder = new();

        private void AddWord(string word)
        {
            if (!_dictionaryOfWordsWithQuantity.ContainsKey(word))
            {
                _dictionaryOfWordsWithQuantity.Add(word, 1);
            }
            else
            {
                _dictionaryOfWordsWithQuantity[word]++;
            }

            AmountOfWords++;
        }
        
        public IEnumerable<WordWithPercent> GetAnalyzeSourceTextResults(string text)
        {
            throw new NotImplementedException();
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
                    if (string.IsNullOrEmpty(_stringBuilder.ToString())) continue;
                    AddWord(_stringBuilder.ToString());
                    _stringBuilder.Clear();
                }
            }

            if (_stringBuilder.ToString() != string.Empty ||
                _stringBuilder.ToString() != "")
            {
                AddWord(_stringBuilder.ToString());
            }
        }
        
        public IEnumerable<WordWithPercent> GetWordsFrequency()
        {
            var result = new List<WordWithPercent>();

            foreach (var word in _dictionaryOfWordsWithQuantity)
            {
                var frequency = Math.Round(word.Value / (double)AmountOfWords, Numbers.Integers.Two);
                result.Add(new WordWithPercent(word.Key, frequency, frequency * Numbers.Integers.OneHundred));
            }

            return result.OrderByDescending(w => w.Frequency);
        }

    }
}
