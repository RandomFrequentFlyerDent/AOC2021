using Answers.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class HydrothermalLogicTests
    {
        private readonly List<string> _input = new()
        {
            "0,9-> 5,9",
            "8,0-> 0,8",
            "9,4-> 3,4",
            "2,2-> 2,1",
            "7,0-> 7,4",
            "6,4-> 2,0",
            "0,9-> 2,9",
            "3,4-> 1,4",
            "0,0-> 8,8",
            "5,5-> 8,2"
        };

        [TestCase(false,"5")]
        [TestCase(true,"12")]
        public void GetOverlap(bool determinDiagonalVents, string expected)
        {
            Assert.AreEqual(expected, HydrothermalLogic.GetOverlap(_input, determinDiagonalVents));
        }
    }
}
