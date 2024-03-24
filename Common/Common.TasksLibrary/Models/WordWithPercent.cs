using System.Globalization;

namespace Common.TasksLibrary.Models
{
    sealed class WordWithPercent
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
            return $"{this.Word}, {this.Frequency}, {this.Percent}";
        }
    }
}
