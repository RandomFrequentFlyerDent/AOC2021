using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class LavaTubeLogicTests
    {
        private readonly List<string> _input = new()
        {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678"
        };

        [Test]
        public void GetRiskLevels()
        {
            Assert.AreEqual("15", LavaTubeLogic.GetRiskLevels(_input));
        }

        [Test]
        public void GetBasinSize()
        {
            Assert.AreEqual("1134", LavaTubeLogic.GetBasinSize(_input));
        }
    }
}
