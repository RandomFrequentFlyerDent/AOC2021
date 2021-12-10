using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayTenPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day10part1.txt");
            return SyntaxScoringLogic.GetCorruptedLines(input);
        }

        public int GetMenuOrder()
        {
            return 19;
        }

        public string GetMenuTitle()
        {
            return "Day Ten Part One";
        }
    }

    internal class DayTenPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day10part1.txt");
            return SyntaxScoringLogic.GetAutoCompleteScore(input);
        }

        public int GetMenuOrder()
        {
            return 20;
        }

        public string GetMenuTitle()
        {
            return "Day Ten Part Two";
        }
    }
}
