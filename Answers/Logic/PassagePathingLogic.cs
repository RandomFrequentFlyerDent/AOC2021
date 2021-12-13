using Answers.Model;

namespace Answers.Logic
{
    public class PassagePathingLogic
    {
        public static string GetPaths(List<string> input)
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

            var startCave = caves.Single(cave => cave.Identifier == "start");
            var path = new List<Cave> { startCave };
            var paths = new List<List<Cave>> { path };
            var completedPaths = GetPaths(paths);
            return completedPaths.Count.ToString();
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

        private static List<Cave> Copy(List<Cave> original)
        {
            List<Cave> copy = new();
            original.ForEach(cave => copy.Add(cave));
            return copy;
        }
    }
}
