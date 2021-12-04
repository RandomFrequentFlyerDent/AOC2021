using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayFourPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day4part1.txt");
            return BingoLogic.GetFinalScore(input, squidWin: false);
        }

        public int GetMenuOrder()
        {
            return 7;
        }

        public string GetMenuTitle()
        {
            return "Day Four Part One";
        }
    }

    internal class DayFourPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day4part1.txt");
            return BingoLogic.GetFinalScore(input, squidWin: true);
        }

        public int GetMenuOrder()
        {
            return 8;
        }

        public string GetMenuTitle()
        {
            return "Day Four Part Two";
        }
    }
}
