using Common.TasksLibrary.Constants;

namespace Common.TasksLibrary.Task1
{
    public class WordWithPercent : IComparable<WordWithPercent>
    {
        private string Word { get; }
        private double Frequency { get; }
        private double Percent { get; }

        public WordWithPercent(string word, double frequency)
        {
            Word = word;
            Frequency = frequency;
            Percent = frequency * IntegersConstants.MaxPercent;
        }

        public int CompareTo(WordWithPercent other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.Frequency.CompareTo(other.Frequency);
        }

        public override bool Equals(object obj)
        {
            var other = obj as WordWithPercent;
            
            if(other == null)
            {
                return false;
            }

            return Math.Abs(this.Frequency - other.Frequency) < DoublesConstants.Tolerance
                   && Math.Abs(this.Percent - other.Percent) < DoublesConstants.Tolerance
                   && Word.Equals(other.Word);
        }
        

        public override int GetHashCode()
        {
            return HashCode.Combine(Word, Frequency, Percent);
        }

        public override string ToString()
        {
            return FormattableString.Invariant($"{this.Word}, {this.Frequency}, {this.Percent}");
        }
    }
}
