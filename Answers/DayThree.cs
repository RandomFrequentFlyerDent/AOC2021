using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayThreePartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day3part1.txt");
            return PowerConsumptionLogic.GetPowerConsumption(input);
        }

        public int GetMenuOrder()
        {
            return 5;
        }

        public string GetMenuTitle()
        {
            return "Day Three Part One";
        }
    }

    internal class DayThreePartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day3part1.txt");
            return LifeSupportLogic.GetRating(input);
        }

        public int GetMenuOrder()
        {
            return 6;
        }

        public string GetMenuTitle()
        {
            return "Day Three Part Two";
        }
    }
}
