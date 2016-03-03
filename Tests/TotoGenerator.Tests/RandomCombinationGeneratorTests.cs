using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TotoGenerator.Common;
using TotoGenerator.Combinations;
using System.Collections.Generic;
using System.Linq;

namespace TotoGenerator.Tests
{
    [TestClass]
    public class RandomCombinationGeneratorTests
    {
        private RandomCombinationGenerator generator = new RandomCombinationGenerator();

        [TestMethod]
        public void GetZodiacShouldReturnNumberWithinTheGivenRange()
        {
            var maxValue = 10;

            for (int i = 0; i < 10000; i++)
            {
                var numberFromGenerator = this.generator.GetZodiac(maxValue);
                Assert.IsTrue(maxValue >= numberFromGenerator && numberFromGenerator >= 1);
            }
        }

        [TestMethod]
        public void GetNumbersShouldReturnUniqueNumbersWithinTheGivenRange()
        {
            var combination = new StandardCombination(1,10,5);
            var hashset = new HashSet<int>();
            generator.GetNumbers(combination).ToList().ForEach(x => hashset.Add(x));
            Assert.AreEqual(combination.TotalNumbers, hashset.Count);

            generator.GetNumbers(combination).ToList().ForEach(x => Assert.IsTrue(x>=combination.MinimumValue && x<= combination.MaximumValue));
        }

        [TestMethod]
        public void GetNumbersShouldIncludeTheMinAndMaxRangeAsNumbersOptions()
        {
            var startNumber = 1;
            var endNumber = 3;
            var totalNumbers = 3;

            var combination = new StandardCombination(startNumber, endNumber, totalNumbers);
            var result = generator.GetNumbers(combination);
            for (int i = 1; i <= endNumber; i++)
            {
                Assert.IsTrue(result.Contains(i));
            }
        }

        [TestMethod]
        public void GetNumbersShouldReturnNumbersEqualToTheCombinationTotalNumbers()
        {
            var startNumber = 1;
            var endNumber = 500;
            var totalNumbers = 400;

            var combination = new StandardCombination(startNumber, endNumber, totalNumbers);
            var result = generator.GetNumbers(combination);
            Assert.IsTrue(result.Count == totalNumbers);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetNumbersShouldThrowIfMaxValueIsLessThanTotalNumbers()
        {
            var startNumber = 1;
            var endNumber = 100;
            var totalNumbers = 101;

            var combination = new StandardCombination(startNumber, endNumber, totalNumbers);
            var result = generator.GetNumbers(combination);
        }
    }
}
