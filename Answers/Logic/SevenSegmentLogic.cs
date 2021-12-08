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
                    signalPattern.Pattern[i] = groups[i].Value;
                for (int i = 0; i < 4; i++)
                    signalPattern.Output[i] = groups[10 + 1].Value;
                patterns.Add(signalPattern);
            });

            return string.Empty;
        }

        internal class SignalPattern
        {
            public string[] Pattern { get; set; } = new string[10];
            public string[] Output { get; set; } = new string[4];

        }
    }
}
