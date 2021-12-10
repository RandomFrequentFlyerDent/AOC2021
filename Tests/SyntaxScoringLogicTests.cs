using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class SyntaxScoringLogicTests
    {
        private readonly List<string> _input = new()
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]"
        };

        [Test]
        public void GetCorruptedLines()
        {
            Assert.AreEqual("26397", SyntaxScoringLogic.GetCorruptedLines(_input));
        }

        [Test]
        public void GetMiddleScore()
        {
            Assert.AreEqual("288957", SyntaxScoringLogic.GetAutoCompleteScore(_input));
        }
    }
}
