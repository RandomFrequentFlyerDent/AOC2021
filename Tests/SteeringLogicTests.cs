using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class SteeringLogicTests
    {
        private readonly List<string> _input = new()
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        [Test]
        public void GetPosition()
        {
            Assert.AreEqual("150", SteeringLogic.GetPosition(_input));
        }

        [Test]
        public void GetPositionWithAim()
        {
            Assert.AreEqual("900", SteeringLogic.GetPositionWithAim(_input));
        }
    }
}
