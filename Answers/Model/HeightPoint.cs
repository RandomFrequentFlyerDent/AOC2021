namespace Answers.Model
{
    public class HeightPoint
    {
        public int Position { get; set; }
        public bool IsPeak { get; set; }
        public int? BasinIdentifier { get; set; }

        public HeightPoint(int position, char height)
        {
            Position = position;
            IsPeak = height == '9';
        }
    }
}
