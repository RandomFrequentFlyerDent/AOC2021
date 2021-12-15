using System.Drawing;

namespace Answers.Model
{
    public class HeightPoint
    {
        public Point Position { get; set; }
        public int Height { get; set; }
        public bool IsPeak { get; set; }
        public bool Checked { get; set; }

        public HeightPoint(int x, int y, char height)
        {
            Position = new Point(x,y);
            Height = int.Parse(height.ToString());
            if (height == '9')
                IsPeak = true;
        }
    }
}
