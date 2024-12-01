using System.Text;

namespace Common.TasksLibrary.Task1;

public static class WordFrequencyAnalyzer
{
    public static IEnumerable<WordWithPercent> GetAnalyzeSourceTextResults(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new Exception("WordFrequencyAnalyzer received an empty string or null.");
        }

        var dictionaryOfWordsWithQuantity = GetWordsIntoAnalyzerFromText(text);

        return GetWordsFrequency(dictionaryOfWordsWithQuantity);
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

    private static IDictionary<string, int> GetWordsIntoAnalyzerFromText(string text)
    {
        var stringBuilder = new StringBuilder();

        var dictionaryOfWordsWithQuantity = new Dictionary<string, int>();

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

                dictionaryOfWordsWithQuantity.AddWord(stringBuilder.ToString());

                stringBuilder.Clear();
            }
        }

        if (stringBuilder.ToString() != string.Empty)
        {
            dictionaryOfWordsWithQuantity.AddWord(stringBuilder.ToString());
        }

        return dictionaryOfWordsWithQuantity;
    }

    private static IEnumerable<WordWithPercent> GetWordsFrequency(IDictionary<string, int> dictionary)
    {
        var result = new List<WordWithPercent>();

        foreach (var word in dictionary)
        {
            var frequency = Math.Round(word.Value / (double)dictionary.GetAmountOfWords(), 
                Numbers.Integers.Two);

            result.Add(new WordWithPercent(word.Key, 
                frequency, 
                frequency * Numbers.Integers.OneHundred));
        }

        return result.OrderByDescending(w => w.Frequency);
    }
}