using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayElevenPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day11part1.txt");
            return DumboOctopusLogic.GetFlashes(input);
        }

        public int GetMenuOrder()
        {
            return 21;
        }

        public string GetMenuTitle()
        {
            return "Day Eleven Part One";
        }
    }

    internal class DayElevenPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day11part1.txt");
            return DumboOctopusLogic.GetSynchronizedFlash(input);
        }

        public int GetMenuOrder()
        {
            return 22;
        }

        public string GetMenuTitle()
        {
            return "Day Eleven Part Two";
        }
    }
}
