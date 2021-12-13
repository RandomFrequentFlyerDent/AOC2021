using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayTwelvePartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day12part1.txt");
            return PassagePathingLogic.GetPaths(input, false);
        }

        public int GetMenuOrder()
        {
            return 23;
        }

        public string GetMenuTitle()
        {
            return "Day Twelve Part One";
        }
    }

    internal class DayTwelvePartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day12part1.txt");
            return PassagePathingLogic.GetPaths(input, true);
        }

        public int GetMenuOrder()
        {
            return 24;
        }

        public string GetMenuTitle()
        {
            return "Day Twelve Part Two";
        }
    }
}
