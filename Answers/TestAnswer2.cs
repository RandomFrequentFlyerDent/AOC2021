namespace Answers
{
    internal class TestAnswer2 : IAnswer
    {
        public string Get()
        {
            return "1000";
        }

        public int GetMenuOrder()
        {
            return 1;
        }

        public string GetMenuTitle()
        {
            return "test 2";
        }
    }
}
