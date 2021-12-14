using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayThirteenPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day13part1.txt");
            return OrigamiLogic.GetNumberOfDotsOnFirstFold(input);
        }

        public int GetMenuOrder()
        {
            return 25;
        }

        public string GetMenuTitle()
        {
            return "Day Thirteen Part One";
        }
    }

    internal class DayThirteenPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day13part1.txt");
            return OrigamiLogic.Fold(input);
        }

        public int GetMenuOrder()
        {
            return 26;
        }

        public string GetMenuTitle()
        {
            return "Day Thirteen Part Two";
        }
    }
}
