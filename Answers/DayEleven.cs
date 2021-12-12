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
            List<string> input = new()
            {
                "5483143223",
                "2745854711",
                "5264556173",
                "6141336146",
                "6357385478",
                "4167524645",
                "2176841721",
                "6882881134",
                "4846848554",
                "5283751526"
            };
//            var input = InputReader.ReadFile("day11part1.txt");
            return DumboOctopusLogic.GetFlashes(input);
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
