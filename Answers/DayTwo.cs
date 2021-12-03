using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayTwoPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day2part1.txt");
            return SteeringLogic.GetPosition(input);
        }

        public int GetMenuOrder()
        {
            return 3;
        }

        public string GetMenuTitle()
        {
            return "Day Two Part One";
        }
    }

    internal class DayTwoPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day2part1.txt");
            return SteeringLogic.GetPositionWithAim(input);
        }

        public int GetMenuOrder()
        {
            return 4;
        }

        public string GetMenuTitle()
        {
            return "Day Two Part Two";
        }
    }
}
