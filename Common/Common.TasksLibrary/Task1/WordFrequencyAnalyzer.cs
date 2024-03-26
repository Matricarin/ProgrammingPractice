using System.Text;
using Common.TasksLibrary.Models;

namespace Common.TasksLibrary.Task1;

public static class WordFrequencyAnalyzer
{
    public static IEnumerable<WordWithPercent> GetAnalyzeSourceTextResults(string text)
    {
        GetWordsIntoAnalyzerFromText(text);
        return GetWordsFrequency();
    }

    private static int GetAmountOfWords(this IDictionary<string,int> dictionary)
    {
        return dictionary.Sum(w => w.Value);
    }

    private static void AddWord(this IDictionary<string, int> dictionary, string word)
    {
        if (!dictionary.ContainsKey(word))
        {
            dictionary.Add(word, 1);
        }
        else
        {
            dictionary[word]++;
        }
    }

    private static void GetWordsIntoAnalyzerFromText(string text)
    {
        foreach (var ch in text)
        {
            if (char.IsLetterOrDigit(ch))
            {
                _stringBuilder.Append(ch);
            }
            else if (ch.ToString() == Environment.NewLine)
            {
                continue;
            }
            else
            {
                if (string.IsNullOrEmpty(_stringBuilder.ToString()))
                {
                    continue;
                }
                AddWord(_stringBuilder.ToString());
                _stringBuilder.Clear();
            }
        }

        if (_stringBuilder.ToString() != string.Empty)
        {
            AddWord(_stringBuilder.ToString());
        }
    }

    private static IEnumerable<WordWithPercent> GetWordsFrequency(IDictionary<string, int> dictionary)
    {
        var result = new List<WordWithPercent>();

        foreach (var word in dictionary)
        {
            var frequency = Math.Round(word.Value / (double)dictionary.GetAmountOfWords(), Numbers.Integers.Two);
            result.Add(new WordWithPercent(word.Key, frequency, frequency * Numbers.Integers.OneHundred));
        }

        return result.OrderByDescending(w => w.Frequency);
    }
}