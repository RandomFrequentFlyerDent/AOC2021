using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DayFive : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day5part1.txt");
            return HydrothermalLogic.GetOverlap(input);
        }

        public int GetMenuOrder()
        {
            return 9;
        }

        public string GetMenuTitle()
        {
            return "Day Five Part One";
        }
    }
}
