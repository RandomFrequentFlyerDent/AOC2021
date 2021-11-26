namespace Answers
{
    internal class TestAnswer1 : IAnswer
    {
        public string Get()
        {
            return "1";
        }

        public int GetMenuOrder()
        {
            return 2;
        }

        public string GetMenuTitle()
        {
            return "test title 1";
        }
    }
}
