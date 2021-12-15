namespace Answers.Model
{
    public class PairInsertionRule
    {
        public string Pair { get; set; }
        public char First { get; set; }
        public char Second { get; set; }
        public char Insertion { get; set; }

        public bool ShouldInsert(char first, char second, out char insertion)
        {
            insertion = Insertion;
            if (first == First && second == Second)
                return true;
            return false;
        }
    }
}
