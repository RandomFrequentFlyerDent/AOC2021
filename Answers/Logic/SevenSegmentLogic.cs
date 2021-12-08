using Answers.Model;
using System.Text.RegularExpressions;

namespace Answers.Logic
{
    public class SevenSegmentLogic
    {
        public static string GetEasyDigitsOccurence(List<string> input)
        {
            var regex = new Regex(@"(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s\|\s(\w+)\s(\w+)\s(\w+)\s(\w+)");
            List<SignalPattern> patterns = new();
            input.ForEach(line =>
            {
                MatchCollection matches = regex.Matches(line);
                GroupCollection groups = matches[0].Groups;
                var signalPattern = new SignalPattern();
                for (int i = 0; i < 10; i++)
                    signalPattern.Pattern[i] = groups[i + 1].Value;
                for (int i = 0; i < 4; i++)
                    signalPattern.Output[i] = groups[i + 11].Value;
                patterns.Add(signalPattern);
            });

            return patterns
                .Sum(p => p.GetEasyNumbersOutput().Count())
                .ToString();
        }
    }
}
