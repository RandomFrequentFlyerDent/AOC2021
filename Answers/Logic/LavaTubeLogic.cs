using Answers.Model;

namespace Answers.Logic
{
    public class LavaTubeLogic
    {
        public static string GetRiskLevels(List<string> input)
        {
            var heightMap = GetHeightMap(input);
            var lowestPoints = GetLowestPoints(heightMap);
            return lowestPoints.Sum(p => p.Height + 1).ToString();
        }

        public static string GetBasinSize(List<string> input)
        {

            var map = GetHeightMap(input);
            var lowestPoints = GetLowestPoints(map);
            List<List<HeightPoint>> basins = new();

            lowestPoints.ForEach(point =>
            {
                basins.Add(GetBasin(point, map));
            });

            return basins.OrderByDescending(b => b.Count)
                .Take(3).Select(b => b.Count)
                .Aggregate(1, (x, y) => x * y)
                .ToString();
        }

        private static List<HeightPoint> GetHeightMap(List<string> input)
        {
            List<HeightPoint> map = new();

            for (int line = 0; line < input.Count; line++)
            {
                for (int position = 0; position < input[0].Length; position++)
                {
                    HeightPoint heightPoint = new(position, line, input[line][position]);
                    map.Add(heightPoint);
                }
            }

            return map;
        }

        private static List<HeightPoint> GetLowestPoints(List<HeightPoint> heightMap)
        {
            List<HeightPoint> lowestPoints = new();
            heightMap.ForEach(heightPoint =>
            {
                var above = heightMap.Where(h => h.Position == new System.Drawing.Point(heightPoint.Position.X, heightPoint.Position.Y - 1)).SingleOrDefault();
                var below = heightMap.Where(h => h.Position == new System.Drawing.Point(heightPoint.Position.X, heightPoint.Position.Y + 1)).SingleOrDefault();
                var left = heightMap.Where(h => h.Position == new System.Drawing.Point(heightPoint.Position.X - 1, heightPoint.Position.Y)).SingleOrDefault();
                var right = heightMap.Where(h => h.Position == new System.Drawing.Point(heightPoint.Position.X + 1, heightPoint.Position.Y)).SingleOrDefault();

                if ((above == null || above.Height > heightPoint.Height) &&
                    (below == null || below.Height > heightPoint.Height) &&
                    (right == null || right.Height > heightPoint.Height) &&
                    (left == null || left.Height > heightPoint.Height))
                    lowestPoints.Add(heightPoint);
            });
            return lowestPoints;
        }

        private static List<HeightPoint> GetBasin(HeightPoint lowestPoint, List<HeightPoint> heightMap)
        {
            List<HeightPoint> basin = new();
            List<HeightPoint> tempBasin = new();
            basin.Add(lowestPoint);
            bool searching = true;

            do
            {
                if (basin.All(h => h.Checked))
                {
                    searching = false;
                }
                else
                {
                    tempBasin.Clear();
                    tempBasin = Copy(basin).Where(p => !p.Checked).ToList();
                    foreach (var point in tempBasin)
                    {
                        var above = heightMap.Where(h => h.Position == new System.Drawing.Point(point.Position.X, point.Position.Y - 1)).SingleOrDefault();
                        var below = heightMap.Where(h => h.Position == new System.Drawing.Point(point.Position.X, point.Position.Y + 1)).SingleOrDefault();
                        var left = heightMap.Where(h => h.Position == new System.Drawing.Point(point.Position.X - 1, point.Position.Y)).SingleOrDefault();
                        var right = heightMap.Where(h => h.Position == new System.Drawing.Point(point.Position.X + 1, point.Position.Y)).SingleOrDefault();

                        if (above != null && !above.IsPeak && !basin.Contains(above))
                            basin.Add(above);
                        if (below != null && !below.IsPeak && !basin.Contains(below))
                            basin.Add(below);
                        if (left != null && !left.IsPeak && !basin.Contains(left))
                            basin.Add(left);
                        if (right != null && !right.IsPeak && !basin.Contains(right))
                            basin.Add(right);
                        
                        point.Checked = true;
                    }
                }

            } while (searching);

            return basin;
        }

        private static List<HeightPoint> Copy(List<HeightPoint> original)
        {
            List<HeightPoint> copy = new();
            original.ForEach(h => copy.Add(h));
            return copy;
        }
    }
}
