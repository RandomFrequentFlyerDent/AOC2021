using Answers.Logic;
using Answers.Utilities;

namespace Answers
{
    internal class DaySixPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day6part1.txt");
            return LaternFishBreedingLogic.GetNumberOfFish(input, 80);
        }

        public int GetMenuOrder()
        {
            return 11;
        }

        public string GetMenuTitle()
        {
            return "Day Six Part One";
        }
    }

    internal class DaySixPartTwo : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day6part1.txt");
            return LaternFishBreedingLogic.GetNumberOfFish(input, 256);
        }

        public int GetMenuOrder()
        {
            return 12;
        }

        public string GetMenuTitle()
        {
            return "Day Six Part Two";
        }
    }
}
