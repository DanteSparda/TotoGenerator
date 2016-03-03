namespace TotoGenerator.Common.Contracts
{
    using System.Collections.Generic;
    using TotoGenerator.Combinations;

    public interface IRandom
    {
        IList<int> GetNumbers(Combination combination);

        int GetZodiac(int maxValue);
    }
}
