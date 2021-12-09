using Answers.Model;
using System.Text;
using System.Text.RegularExpressions;

namespace Answers.Logic
{
    public class SevenSegmentLogic
    {
        public static string GetEasyDigitsOccurence(List<string> input)
        {

            List<SignalPattern> patterns = GetSignalPatterns(input);

            return patterns
                .Sum(p => p.GetEasyNumbersOutput().Count())
                .ToString();
        }

        public static string GetOutputValues(List<string> input)
        {
            List<SignalPattern> patterns = GetSignalPatterns(input);
            List<int> codes = new();

            foreach (SignalPattern signalPattern in patterns)
            {
                codes.Add(signalPattern.GetCode());
            }

            return codes.Sum().ToString();
        }

        private static List<SignalPattern> GetSignalPatterns(List<string> input)
        {
            List<SignalPattern> patterns = new();
            var regex = new Regex(@"(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s(\w+)\s\|\s(\w+)\s(\w+)\s(\w+)\s(\w+)");
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
            return patterns;
        }
    }
}
