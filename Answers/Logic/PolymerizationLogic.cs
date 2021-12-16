using Answers.Model;
using System.Text.RegularExpressions;

namespace Answers.Logic
{
    public class PolymerizationLogic
    {
        public static string GetPolymerFormula(List<string> input, int numberOfSteps)
        {
            var instructions = GetInstructions(input);
            var insertionRules = new PairInsertionRules(instructions.insertionRules);
            var polymer = instructions.polymer;

            Dictionary<string, long> pairCount = new();
            Dictionary<char, long> elementCount = new();

            for (int position = 0; position < polymer.Length - 1; position++)
            {
                var pair = new string(polymer.Skip(position).Take(2).ToArray());
                if (pairCount.ContainsKey(pair))
                    pairCount[pair]++;
                else
                    pairCount.Add(pair, 1);
            }

            for (int position = 0; position < polymer.Length; position++)
            {
                if (elementCount.ContainsKey(polymer[position]))
                    elementCount[polymer[position]]++;
                else
                    elementCount.Add(polymer[position], 1);
            }

            for (int i = 0; i < numberOfSteps; i++)
                GetElementalCount(insertionRules, pairCount, elementCount);

            return (elementCount.Max(e => e.Value) - elementCount.Min(e => e.Value)).ToString();
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

        private static void GetElementalCount(PairInsertionRules rules, Dictionary<string, long> pairCount, Dictionary<char, long> elementalCount)
        {
            Dictionary<string, long> temp = new();
            foreach (var pair in pairCount)
            {
                var insertion = rules.Apply(pair.Key);

                if (insertion != null)
                {
                    if (elementalCount.ContainsKey(insertion.Value))
                        elementalCount[insertion.Value] += pair.Value;
                    else
                        elementalCount.Add(insertion.Value, pair.Value);

                    var pairOne = pair.Key[0].ToString() + insertion.ToString();
                    if (temp.ContainsKey(pairOne))
                        temp[pairOne] += pair.Value;
                    else
                        temp.Add(pairOne, pair.Value);

                    var pairTwo = insertion.ToString() + pair.Key[1].ToString();
                    if (temp.ContainsKey(pairTwo))
                        temp[pairTwo] += pair.Value;
                    else
                        temp.Add(pairTwo, pair.Value);
                }
                else
                {
                    temp.Add(pair.Key, pair.Value);
                }
            }

            pairCount.Clear();
            foreach (var item in temp)
                pairCount.Add(item.Key, item.Value);
        }
    }
}
