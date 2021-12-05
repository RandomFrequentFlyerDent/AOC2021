using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayFivePartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day5part1.txt");
            return HydrothermalLogic.GetOverlap(input, false);
        }

        public int GetMenuOrder()
        {
            return 9;
        }

        public string GetMenuTitle()
        {
            return "Day Five Part One";
        }
    }

    internal class DayFivePartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day5part1.txt");
            return HydrothermalLogic.GetOverlap(input, true);
        }

        public int GetMenuOrder()
        {
            return 10;
        }

        public string GetMenuTitle()
        {
            return "Day Five Part Two";
        }
    }
}
