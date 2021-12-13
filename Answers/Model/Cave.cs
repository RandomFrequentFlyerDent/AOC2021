namespace Answers.Model
{
    public class Cave
    {
        public string Identifier { get; private set; }
        public bool IsSmall { get; private set; }
        public List<Cave> ConnectingCaves { get; set; } = new();

        public Cave(string identifier)
        {
            Identifier = identifier;
            IsSmall = char.IsLower(identifier[0]);
        }
    }
}
