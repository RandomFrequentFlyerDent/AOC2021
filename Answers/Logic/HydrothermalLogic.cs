using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Answers.Logic
{
    public class HydrothermalLogic
    {
        public static string GetOverlap(List<string> input)
        {
            var regex = new Regex(@"(?<x1>\d+),(?<y1>\d+)\s*->\s*(?<x2>\d+),(?<y2>\d+)");
            var points = new List<Point>();
            input.ForEach(line =>
            {
                MatchCollection matches = regex.Matches(line);
                GroupCollection groups = matches[0].Groups;
                var x1 = int.Parse( groups["x1"].Value);
                var x2 = int.Parse( groups["x2"].Value);
                var y1 = int.Parse( groups["y1"].Value);
                var y2 = int.Parse( groups["y2"].Value);

                if (x1 == x2 && y1 < y2)
                    points.AddRange(GetHorizontalRangeOfPoints(y1, y2, x1));
                if (x1 == x2 && y1 > y2)
                    points.AddRange(GetHorizontalRangeOfPoints(y2, y1, x1));
                if (x1 < x2 && y1 == y2)
                    points.AddRange(GetVerticalRangeOfPoints(x1, x2, y1));
                if (x1 > x2 && y1 == y2)
                    points.AddRange(GetVerticalRangeOfPoints(x2, x1, y1));
            });

            var pointsByOccurence = points.GroupBy(point => point).ToDictionary(point => point.Key, point => point.Count());
            var overlap = pointsByOccurence.Where(p => p.Value > 1).Count();

            return overlap.ToString();
        }

        private static List<Point> GetHorizontalRangeOfPoints(int begin, int end, int fixedY)
        {
            List<Point> points = new();
            for (int i = begin; i <= end; i++)
                points.Add(new Point(i, fixedY));
            return points;
        }

        private static List<Point> GetVerticalRangeOfPoints(int begin, int end, int fixedX)
        {
            List<Point> points = new();
            for (int i = begin; i <= end; i++)
                points.Add(new Point(fixedX, i));
            return points;
        }

    }
}
