using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class DumboOctopusLogicTests
    {
        private readonly List<string> _input = new()
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        };

        [Test]
        public void GetFlashes()
        {
            Assert.AreEqual("1656", DumboOctopusLogic.GetFlashes(_input));
        }

        [Test]
        public void GetSynchronizedFlash()
        {
            Assert.AreEqual("195", DumboOctopusLogic.GetSynchronizedFlash(_input));
        }
    }
}
