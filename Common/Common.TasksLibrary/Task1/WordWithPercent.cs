namespace Common.TasksLibrary.Task1
{
    public sealed class WordWithPercent
    {
        public WordWithPercent(string word, double frequency, double percent)
        {
            Word = word;
            Frequency = frequency;
            Percent = percent;
        }

        public string Word { get; }
        public double Frequency { get; }
        public double Percent { get; }

        public override string ToString()
        {
            return FormattableString.Invariant($"{this.Word}, {this.Frequency}, {this.Percent}");
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var other = (WordWithPercent)obj;
            return Math.Abs(this.Frequency - other.Frequency) < Constants.Tolerance
                   && Math.Abs(this.Percent - other.Percent) < Constants.Tolerance
                   && this.Word == other.Word;
        }

        public override int GetHashCode()
        {
            return this.Frequency.GetHashCode() 
                   + this.Percent.GetHashCode() 
                   + this.Word.GetHashCode();
        }
    }
}
