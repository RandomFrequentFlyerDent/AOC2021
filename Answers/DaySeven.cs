using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DaySevenPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day7part1.txt");
            return CrabSubmarineLogic.GetFuelConsumption(input, false);
        }

        public int GetMenuOrder()
        {
            return 13;
        }

        public string GetMenuTitle()
        {
            return "Day Seven Part One";
        }
    }

    internal class DaySevenPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day7part1.txt");
            return CrabSubmarineLogic.GetFuelConsumption(input, true);
        }

        public int GetMenuOrder()
        {
            return 14;
        }

        public string GetMenuTitle()
        {
            return "Day Seven Part Two";
        }
    }
}
