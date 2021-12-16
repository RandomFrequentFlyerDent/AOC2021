using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayFourteenPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day14part1.txt");
            return PolymerizationLogic.GetPolymerFormula(input, 10);
        }

        public int GetMenuOrder()
        {
            return 27;
        }

        public string GetMenuTitle()
        {
            return "Day Fourteen Part One";
        }
    }

    internal class DayFourteenPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day14part1.txt");
            return PolymerizationLogic.GetPolymerFormula(input, 40);
        }

        public int GetMenuOrder()
        {
            return 28;
        }

        public string GetMenuTitle()
        {
            return "Day Fourteen Part Two";
        }
    }
}
