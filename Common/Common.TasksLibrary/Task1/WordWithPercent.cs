using System.Diagnostics;
using System.Diagnostics.Contracts;
using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;

namespace Common.TasksLibrary.Task1;

public sealed class WordWithPercent : IComparable<WordWithPercent>
{
    private readonly string _word;
    private readonly double _frequency;
    private readonly double _percent;

    public WordWithPercent(string word, double frequency)
    {
        Debug.Assert(string.IsNullOrEmpty(word), $"Parameter word {nameof(WordWithPercent)} is null or empty");
        Debug.Assert(Math.Abs(0 - frequency) < DoublesConstants.Tolerance,
            "Parameter frequency cant be less than zero");

        _word = word;
        _frequency = frequency;
        _percent = frequency * IntegersConstants.MaxPercent;
    }
    
    [Pure]
    public int CompareTo(WordWithPercent? other)
    {
        if (other.IsNull())
        {
            return 1;
        }

        return _frequency.CompareTo(other._frequency);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as WordWithPercent;

        if (other.IsNull())
        {
            return false;
        }

        return Math.Abs(_frequency - other._frequency) < DoublesConstants.Tolerance
               && Math.Abs(_percent - other._percent) < DoublesConstants.Tolerance
               && _word.Equals(other._word);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(_word, _frequency, _percent);
    }

    public override string ToString()
    {
        return FormattableString.Invariant($"{_word}, {_frequency}, {_percent}");
    }
}