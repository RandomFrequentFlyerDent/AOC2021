using Answers.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PolymerizationLogicTests
    {
        private readonly List<string> _input = new()
        {
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C"
        };

        [TestCase(10, "1588")]
        [TestCase(40, "2188189693529")]
        public void GetPolymerFormula(int numberOfSteps, string expected)
        {
            Assert.AreEqual(expected, PolymerizationLogic.GetPolymerFormula(_input, numberOfSteps));
        }
    }
}
