using System.Text;
using Common.TasksLibrary.Constants;

namespace Common.TasksLibrary.Task1;

public class WordFrequencyAnalyzer
{
    private Dictionary<string, int> _dictionaryOfWordsWithQuantity;
    
    public WordFrequencyAnalyzer(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new Exception("WordFrequencyAnalyzer received an empty string or null.");
        }
        
        var stringBuilder = new StringBuilder();

        _dictionaryOfWordsWithQuantity = new Dictionary<string, int>();

        foreach (var ch in text)
        {
            if (char.IsLetterOrDigit(ch))
            {
                stringBuilder.Append(ch);
            }
            else if (ch.ToString() == Environment.NewLine)
            {
                continue;
            }
            else
            {
                if (string.IsNullOrEmpty(stringBuilder.ToString()))
                {
                    continue;
                }

                AddWord(stringBuilder.ToString());

                stringBuilder.Clear();
            }
        }

        if (stringBuilder.ToString() != string.Empty)
        {
            AddWord(stringBuilder.ToString());
        }

    }

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
    }

    public IEnumerable<WordWithPercent> GetWordsFrequency()
    {
        var result = new List<WordWithPercent>();
        
        var amountOfWords = _dictionaryOfWordsWithQuantity.Sum(w => w.Value);
        
        foreach (var word in _dictionaryOfWordsWithQuantity)
        {
            var frequency = Math.Round(word.Value / (double)amountOfWords, 
                FractionalDigits.Two);

            result.Add(new WordWithPercent(word.Key, frequency));
        }

        return result.OrderByDescending(w => w);
    }
}