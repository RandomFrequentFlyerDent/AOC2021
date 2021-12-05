using System.Drawing;
using System.Text.RegularExpressions;

namespace Answers.Logic
{
    public class HydrothermalLogic
    {
        public static string GetOverlap(List<string> input, bool determineDiagonalVents)
        {
            var regex = new Regex(@"(?<x1>\d+),(?<y1>\d+)\s*->\s*(?<x2>\d+),(?<y2>\d+)");
            var vents = new List<Point>();
            input.ForEach(line =>
            {
                MatchCollection matches = regex.Matches(line);
                GroupCollection groups = matches[0].Groups;
                var x1 = int.Parse(groups["x1"].Value);
                var x2 = int.Parse(groups["x2"].Value);
                var y1 = int.Parse(groups["y1"].Value);
                var y2 = int.Parse(groups["y2"].Value);

                if (x1 == x2 && y1 < y2)
                    vents.AddRange(GetHorizontalVents(y1, y2, x1));
                else if (x1 == x2 && y1 > y2)
                    vents.AddRange(GetHorizontalVents(y2, y1, x1));
                else if (x1 < x2 && y1 == y2)
                    vents.AddRange(GetVerticalVents(x1, x2, y1));
                else if (x1 > x2 && y1 == y2)
                    vents.AddRange(GetVerticalVents(x2, x1, y1));
                else if (determineDiagonalVents)
                    vents.AddRange(GetDiagonalVents(x1, x2, y1, y2));
            });

            var ventsByOccurence = vents.GroupBy(vent => vent).ToDictionary(vent => vent.Key, vent => vent.Count());
            var overlap = ventsByOccurence.Where(v => v.Value > 1).Count();

            return overlap.ToString();
        }

        private static List<Point> GetHorizontalVents(int begin, int end, int fixedY)
        {
            List<Point> vents = new();
            for (int i = begin; i <= end; i++)
                vents.Add(new Point(i, fixedY));
            return vents;
        }

        private static List<Point> GetVerticalVents(int begin, int end, int fixedX)
        {
            List<Point> vents = new();
            for (int i = begin; i <= end; i++)
                vents.Add(new Point(fixedX, i));
            return vents;
        }

        private static List<Point> GetDiagonalVents(int x1, int x2, int y1, int y2)
        {
            List<Point> vents = new();
            if (x1 < x2 && y1 > y2)
            {
                var j = y1;
                for (int i = x1; i <= x2; i++)
                {
                    vents.Add(new Point(i, j));
                    j++;
                }
            }
            else if (x1 > x2 && y1 < y2)
            {
                int j = y2;
                for (int i = x2; i <= x1; i++)
                {
                    vents.Add(new Point(i, j));
                    j--;
                }
            }
            else if (x1 > x2 && y1 > y2)
            {
                int j = y2;
                for (int i = x2; i <= x1; i++)
                {
                    vents.Add(new Point(i, j));
                    j--;
                }
            }
            else if (x1 < x2 && y1 < y2)
            {
                int j = y1;
                for (int i = x1; i <= x2; i++)
                {
                    vents.Add(new Point(i, j));
                    j++;
                }
            }
            
            return vents;
        }
    }
}
