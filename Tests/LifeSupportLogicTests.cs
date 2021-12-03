using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class LifeSupportLogicTests
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
        public void GetRating()
        {
            Assert.AreEqual("230", LifeSupportLogic.GetRating(_input));
        }
    }
}
