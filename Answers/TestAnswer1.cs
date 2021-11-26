namespace Answers
{
    internal class TestAnswer1 : IAnswer
    {
        public string Get()
        {
            return "1";
        }

        public int GetOrder()
        {
            return 2;
        }

        public string GetTitle()
        {
            return "test title 1";
        }
    }
}
