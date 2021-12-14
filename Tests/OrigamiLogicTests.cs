using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class OrigamiLogicTests
    {
        private readonly List<string> _input = new()
        {
            "6,10",
            "0,14",
            "9,10",
            "0,3",
            "10,4",
            "4,11",
            "6,0",
            "6,12",
            "4,1",
            "0,13",
            "10,12",
            "3,4",
            "3,0",
            "8,4",
            "1,10",
            "2,14",
            "8,10",
            "9,0",
            "",
            "fold along y=7",
            "fold along x=5"
        };

        [Test]
        public void GetNumberOfDots()
        {
            Assert.AreEqual("17", OrigamiLogic.GetNumberOfDotsOnFirstFold(_input));
        }
    }
}
