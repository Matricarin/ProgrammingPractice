using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Analyzer
    {
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

            foreach (var word in _dict)
            {
                var freq = word.Value / _amountOfWords;
                yield return (word.Key, freq, freq * 100);
            }
        }
    }
}
