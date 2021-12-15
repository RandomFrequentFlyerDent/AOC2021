using Answers.Model;
using System.Text;
using System.Text.RegularExpressions;

namespace Answers.Logic
{
    public class PolymerizationLogic
    {
        public static string GetPolymerFormula(List<string> input, int numberOfSteps)
        {
            var instructions = GetInstructions(input);
            var polymer = instructions.polymer;
            StringBuilder appendedPolymer = new();

            for (int step = 0; step < numberOfSteps; step++)
            {
                for (int position = 0; position < polymer.Length - 1; position++)
                {
                    var rule = instructions.insertionRules
                        .SingleOrDefault(r => r.Pair[0] == polymer[position] && r.Pair[1] == polymer[position + 1]);
                    appendedPolymer.Append(polymer[position]);
                    if (rule != null) appendedPolymer.Append(rule.Insertion);
                }
                appendedPolymer.Append(polymer.Last());
                polymer = appendedPolymer.ToString();
                appendedPolymer.Clear();
            }

            var countByElement = polymer.GroupBy(p => p).ToDictionary(p => p.Key, p => p.Count());

            return (countByElement.Max(e => e.Value) - countByElement.Min(e => e.Value)).ToString();
        }

        private static (string polymer, List<PairInsertionRule> insertionRules) GetInstructions(List<string> input)
        {
            (string polymer, List<PairInsertionRule> insertionRules) instructions = new();
            List<PairInsertionRule> rules = new();

            input.ForEach(line =>
            {
                if (line.Contains("->"))
                {
                    Regex rx = new(@"(?<pair>(?<first>\w)(?<second>\w))\s*->\s*(?<insertion>\w)");
                    GroupCollection groups = rx.Matches(line)[0].Groups;
                    var insertionRule = new PairInsertionRule
                    {
                        Pair = groups["pair"].Value,
                        First = groups["first"].Value[0],
                        Second = groups["second"].Value[0],
                        Insertion = groups["insertion"].Value[0]
                    };

                    rules.Add(insertionRule);
                }
                else if (line.Count() > 0)
                    instructions.polymer = line;
            });

            instructions.insertionRules = rules;

            return instructions;
        }

    }
}
