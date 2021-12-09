using System.Text.RegularExpressions;

namespace Answers.Model
{
    public class SevenSegmentDisplay
    {
        public int? NumberOnDisplay { get; set; }
        public string Pattern { get; set; }

        public SevenSegmentDisplay(string pattern)
        {
            if (pattern.Length == 2)
                NumberOnDisplay = 1;

            if (pattern.Length == 3)
                NumberOnDisplay = 7;

            if (pattern.Length == 4)
                NumberOnDisplay = 4;

            if (pattern.Length == 7)
                NumberOnDisplay = 8;

            Pattern = pattern;
        }


        public char GetRemainingCharacter(List<char> pattern)
        {
            String chars = "[" + String.Concat(pattern) + "]";
            var remaining = Regex.Replace(Pattern, chars, String.Empty);
            if (remaining.Length > 1)
                throw new Exception("More than one character remaining");
            return remaining[0];
        }

        public bool ContainsPattern(List<char> pattern)
        {
            if (pattern.Any(c => !Regex.IsMatch(Pattern, c.ToString())))
                return false;
            return true;
        }

        public bool IsSameOutput(string output)
        {
            if (output.Length != Pattern.Length) return false;
            return output.ToList().All(x => Pattern.Contains(x));
        }
    }
}
