using Answers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class MeasurementLogicTests

    {
        private readonly List<string> _input = new()
        {
            "199",
            "200",
            "208",
            "210",
            "200",
            "207",
            "240",
            "269",
            "260",
            "263"
        };

        [Test]
        public void CountNumberOfDepthIncreasesLineair()
        {
            Assert.AreEqual("7", MeasurementLogic.NumberOfDepthIncreases(_input));
        }
    }
}