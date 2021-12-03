using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class DiagnosticLogicTests
    {
        private readonly List<string> _input = new()
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        [Test]
        public void GetPowerConsumption()
        {
            Assert.AreEqual("198", DiagnosticsLogic.GetPowerConsumption(_input));
        }

        [Test]
        public void GetLifeSupportRating()
        {
            Assert.AreEqual("230", DiagnosticsLogic.GetLifeSupportRating(_input));
        }
    }
}
