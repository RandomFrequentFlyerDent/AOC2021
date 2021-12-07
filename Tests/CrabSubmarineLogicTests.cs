using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class CrabSubmarineLogicTests
    {
        private readonly List<string> _input = new() { "16,1,2,0,4,2,7,1,2,14" };

        [TestCase(false, "37")]
        [TestCase(true, "168")]
        public void getNumberOfFish(bool getCumulative, string expected)
        {
            Assert.AreEqual(expected, CrabSubmarineLogic.GetFuelConsumption(_input, getCumulative));
        }
    }
}
