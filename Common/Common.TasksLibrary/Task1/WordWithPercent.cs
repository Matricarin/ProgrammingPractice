using System.Diagnostics;
using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;

namespace Common.TasksLibrary.Task1;

public sealed class WordWithPercent : IComparable<WordWithPercent>
{
    private string Word { get; }
    private double Frequency { get; }
    private double Percent { get; }

    public WordWithPercent(string word, double frequency)
    {
        Debug.Assert(string.IsNullOrEmpty(word), $"Parameter word {nameof(WordWithPercent)} is null or empty");
        Debug.Assert(Math.Abs(0 - frequency) < DoublesConstants.Tolerance,
            "Parameter frequency cant be less than zero");

        Word = word;
        Frequency = frequency;
        Percent = frequency * IntegersConstants.MaxPercent;
    }

    public int CompareTo(WordWithPercent? other)
    {
        if (other.IsNull())
        {
            return 1;
        }

        return Frequency.CompareTo(other.Frequency);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as WordWithPercent;

        if (other.IsNull())
        {
            return false;
        }

        return Math.Abs(Frequency - other.Frequency) < DoublesConstants.Tolerance
               && Math.Abs(Percent - other.Percent) < DoublesConstants.Tolerance
               && Word.Equals(other.Word);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(Word, Frequency, Percent);
    }

    public override string ToString()
    {
        return FormattableString.Invariant($"{Word}, {Frequency}, {Percent}");
    }
}