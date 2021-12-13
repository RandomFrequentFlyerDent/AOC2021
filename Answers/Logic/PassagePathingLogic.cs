using Answers.Model;
using System.Text;

namespace Answers.Logic
{
    public class PassagePathingLogic
    {
        public static string GetPaths(List<string> input, bool withMultipleSmallCaveVisit)
        {
            List<Cave> caves = GetCaves(input);

            var startCave = caves.Single(cave => cave.Identifier == "start");
            var path = new List<Cave> { startCave };
            var paths = new List<List<Cave>> { path };
            var completedPaths = withMultipleSmallCaveVisit
                ? GetPathsWithMultipleSmallCaveVisit(paths)
                : GetPaths(paths);
            return completedPaths.Count.ToString();
        }

        private static List<Cave> GetCaves(List<string> input)
        {
            List<Cave> caves = new();
            foreach (var line in input)
            {
                var split = line.Split('-');

                string identifier = split[0];
                var caveOne = caves.SingleOrDefault(c => c.Identifier == identifier);
                if (caveOne == null)
                {
                    caveOne = new(identifier);
                    caves.Add(caveOne);
                }

                identifier = split[1];
                var caveTwo = caves.SingleOrDefault(c => c.Identifier == identifier);
                if (caveTwo == null)
                {
                    caveTwo = new(identifier);
                    caves.Add(caveTwo);
                }

                caveOne.ConnectingCaves.Add(caveTwo);
                caveTwo.ConnectingCaves.Add(caveOne);
            }

            return caves;
        }

        private static List<List<Cave>> GetPaths(List<List<Cave>> paths)
        {
            List<List<Cave>> completedPaths = new();
            paths.ForEach(path =>
            {
                var lastCave = path.Last();
                if (!lastCave.Identifier.Equals("end"))
                {
                    lastCave.ConnectingCaves.ForEach(cave =>
                    {
                        if (cave.Identifier != "start" && !(path.Contains(cave) && cave.IsSmall))
                        {
                            var appendedPath = Copy(path);
                            appendedPath.Add(cave);
                            completedPaths.Add(appendedPath);
                        }
                    });
                }
                else
                {
                    var appendedPath = Copy(path);
                    completedPaths.Add(appendedPath);
                }
            });

            if (completedPaths.All(path => path.Last().Identifier == "end"))
                return completedPaths;

            return GetPaths(completedPaths);
        }

        private static List<List<Cave>> GetPathsWithMultipleSmallCaveVisit(List<List<Cave>> paths)
        {
            List<List<Cave>> completedPaths = new();
            paths.ForEach(path =>
            {
                var lastCave = path.Last();
                if (!lastCave.Identifier.Equals("end"))
                {
                    lastCave.ConnectingCaves.ForEach(cave =>
                    {
                        if (cave.Identifier != "start")
                        {
                            var appendedPath = Copy(path);
                            if (cave.IsSmall)
                            {
                                var countsBySmallCaves = path.Where(c => c.IsSmall)
                                                                .GroupBy(c => c.Identifier)
                                                                .ToDictionary(c => c.Key, c => c.Count());
                                if (!countsBySmallCaves.Any(c => c.Value > 1))
                                {
                                    appendedPath.Add(cave);
                                    completedPaths.Add(appendedPath);
                                }
                                else if (!countsBySmallCaves.ContainsKey(cave.Identifier))
                                {
                                    appendedPath.Add(cave);
                                    completedPaths.Add(appendedPath);
                                }
                            }
                            else
                            {
                                appendedPath.Add(cave);
                                completedPaths.Add(appendedPath);
                            }
                        }
                    });
                }
                else
                {
                    var appendedPath = Copy(path);
                    completedPaths.Add(appendedPath);
                }
            });

            if (completedPaths.All(path => path.Last().Identifier == "end"))
                return completedPaths;

            return GetPathsWithMultipleSmallCaveVisit(completedPaths);
        }

        private static List<Cave> Copy(List<Cave> original)
        {
            List<Cave> copy = new();
            original.ForEach(cave => copy.Add(cave));
            return copy;
        }
    }
}
