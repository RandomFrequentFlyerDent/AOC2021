using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Answers.Logic
{
    public class OrigamiLogic
    {
        public static string GetNumberOfDotsOnFirstFold(List<string> input)
        {
            var instructions = GetInstructions(input);
            List<Point> foldedPoints = Fold(instructions.points, instructions.folds.First());

            return foldedPoints.Distinct().Count().ToString();
        }

        private static (List<Point> points, List<(char direction, int line)> folds) GetInstructions(List<string> input)
        {
            List<Point> points = new();
            List<(char direction, int line)> folds = new();

            input.ForEach(line =>
            {
                if (line.Length > 0)
                {

                    if (line.StartsWith("fold"))
                    {
                        Regex rg = new(@"fold along (?<direction>[xy])=(?<line>\d+)");
                        GroupCollection groups = rg.Matches(line)[0].Groups;
                        folds.Add(new(groups["direction"].Value[0], int.Parse(groups["line"].Value)));
                    }
                    else
                    {
                        var coordinates = line.Split(',');
                        points.Add(new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1])));
                    }
                }
            });
            return (points, folds);
        }

        public static string Fold(List<string> input)
        {
            var instructions = GetInstructions(input);
            List<Point> foldedPoints = instructions.points.Select(p => p).ToList();
            for (int instruction = 0; instruction < instructions.folds.Count; instruction++)
            {
                var fold = instructions.folds[instruction];
                var newlyFolded = Fold(foldedPoints, fold);
                foldedPoints.Clear();
                newlyFolded.ForEach(point => foldedPoints.Add(point));
            }

            foldedPoints = foldedPoints.Distinct().OrderBy(points => points.Y).ThenBy(p => p.X).ToList();
            StringBuilder readOut = new("\n\n");
            var furthestPoint = foldedPoints.Max(point => point.X);
            var closestPoint = foldedPoints.Min(point => point.X);
            var lowestPoint = foldedPoints.Max(point => point.Y);
            var highestPoint = foldedPoints.Min(point => point.Y);

            for (int y = highestPoint; y <= lowestPoint; y++)
            {
                for (int x = closestPoint; x <= furthestPoint; x++)
                {
                    if (foldedPoints.Contains(new Point(x, y)))
                        readOut.Append('#');
                    else
                        readOut.Append('.');
                }
                readOut.AppendLine();
            }

            return readOut.ToString();
        }

        private static List<Point> Fold(List<Point> points, (char direction, int line) fold)
        {
            List<Point> foldedPoints = new();
            points.ForEach(point =>
            {
                if (fold.direction == 'y' && point.Y > fold.line)
                    foldedPoints.Add(new Point(point.X, point.Y - ((point.Y - fold.line) * 2)));
                else if (fold.direction == 'x' && point.X > fold.line)
                    foldedPoints.Add(new Point(fold.line - (point.X - fold.line), point.Y));
                else
                    foldedPoints.Add(point);
            });

            return foldedPoints.Distinct().ToList();
        }
    }
}
