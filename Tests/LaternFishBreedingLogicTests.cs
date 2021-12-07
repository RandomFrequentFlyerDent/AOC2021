using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class LaternFishBreedingLogicTests
    {
        private readonly List<string> _input = new() { "3,4,3,1,2" };

        [TestCase(18, "26")]
        [TestCase(80, "5934")]
        [TestCase(256, "26984457539")]
        public void getNumberOfFish(int numberOfDays, string expected)
        {
            Assert.AreEqual(expected, LaternFishBreedingLogic.GetNumberOfFish(_input, numberOfDays));
        }
    }
}
