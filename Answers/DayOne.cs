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
}
