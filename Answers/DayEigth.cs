using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayEigthPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day8part1.txt");
            return SevenSegmentLogic.GetEasyDigitsOccurence(input);
        }

        public int GetMenuOrder()
        {
            return 15;
        }

        public string GetMenuTitle()
        {
            return "Day Eigth Part One";
        }
    }

    internal class DayEigthPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day8part1.txt");
            return SevenSegmentLogic.GetOutputValues(input);
        }

        public int GetMenuOrder()
        {
            return 16;
        }

        public string GetMenuTitle()
        {
            return "Day Eigth Part Two";
        }
    }
}
