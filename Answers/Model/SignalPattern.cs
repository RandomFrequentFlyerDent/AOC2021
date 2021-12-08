namespace Answers.Model
{
    public class SignalPattern
    {
        public string[] Pattern { get; set; } = new string[10];
        public string[] Output { get; set; } = new string[4];

        public string[] GetEasyNumbersOutput()
        {
            return Output
                .Where(o => o.Length == 2 || o.Length == 3 || o.Length == 4 || o.Length == 7)
                .ToArray();
        }
    }
}
