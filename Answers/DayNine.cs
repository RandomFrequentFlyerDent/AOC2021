using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayNinePartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day9part1.txt");
            return LavaTubeLogic.GetRiskLevels(input);
        }

        public int GetMenuOrder()
        {
            return 17;
        }

        public string GetMenuTitle()
        {
            return "Day Nine Part One";
        }
    }

    internal class DayNinePartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day9part1.txt");
            return LavaTubeLogic.GetBasinSize(input);
        }

        public int GetMenuOrder()
        {
            return 18;
        }

        public string GetMenuTitle()
        {
            return "Day Nine Part Two";
        }
    }
}
