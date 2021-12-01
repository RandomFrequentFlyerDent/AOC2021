using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayOnePartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day1part1.txt");
            return MeasurementLogic.NumberOfDepthIncreases(input);
        }

        public int GetMenuOrder()
        {
            return 1;
        }

        public string GetMenuTitle()
        {
            return "Day One Part One";
        }
    }

    internal class DayOnePartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day1part1.txt");
            return MeasurementLogic.NumberOfDepthIncreasesByThreeMeasurementsWindow(input);
        }

        public int GetMenuOrder()
        {
            return 2;
        }

        public string GetMenuTitle()
        {
            return "Day One Part Two";
        }
    }
}
