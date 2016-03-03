namespace TotoGenerator.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TotoGenerator.Combinations;
    using TotoGenerator.Common.Contracts;

    public class RandomCombinationGenerator : IRandom
    {
        private Random random;

        public RandomCombinationGenerator()
        {
            this.random = new Random();
        }

        public IList<int> GetNumbers(Combination combination)
        {
            if (combination.TotalNumbers > combination.MaximumValue)
            {
                throw new ArgumentException("Total numbers must be less or equal to maximum value");
            }

            var numbersToReturn = new List<int>();

            while (numbersToReturn.Count() != combination.TotalNumbers)
            {
                var number = this.random.Next(combination.MinimumValue, combination.MaximumValue + 1);
                if (!numbersToReturn.Contains(number))
                {
                    numbersToReturn.Add(number);
                }
            }

            return numbersToReturn.OrderBy(x => x).ToList();
        }

        public int GetZodiac(int maxValue)
        {
            return this.random.Next(1, maxValue + 1);
        }
    }
}
