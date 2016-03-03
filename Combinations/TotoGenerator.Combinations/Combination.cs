namespace TotoGenerator.Combinations
{
    public abstract class Combination
    {
        public Combination(int minValue, int maxValue, int totalNumbers)
        {
            this.MaximumValue = maxValue;
            this.MinimumValue = minValue;
            this.TotalNumbers = totalNumbers;
        }

        public int MaximumValue { get; private set; }

        public int MinimumValue { get; private set; }

        public int TotalNumbers { get; private set; }
    }
}
