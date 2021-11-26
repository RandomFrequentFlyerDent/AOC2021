namespace Answers
{
    internal class TestAnswer2 : IAnswer
    {
        public string Get()
        {
            return "1000";
        }

        public int GetOrder()
        {
            return 1;
        }

        public string GetTitle()
        {
            return "test 2";
        }
    }
}
