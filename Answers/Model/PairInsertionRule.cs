namespace Answers.Model
{
    public class PairInsertionRule
    {
        public string Pair { get; set; }
        public char Insertion { get; set; }

        public char Apply(string pair)
        {
            if (pair != Pair)
                throw new ArgumentException($"Cannot apply, pair should be {Pair} but was {pair}");
            return Insertion;
        }
    }

    public class PairInsertionRules
    {
        private readonly List<PairInsertionRule> _rules;

        public PairInsertionRules(List<PairInsertionRule> rules)
        {
            _rules = rules;
        }

        public char? Apply(string pair)
        {
            var rule = _rules.SingleOrDefault(r => r.Pair == pair);
            if (rule == null)
                return null;
            return rule.Apply(pair);
        }
    }
}
