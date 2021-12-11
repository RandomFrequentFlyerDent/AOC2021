namespace Answers.Logic
{
    public class LavaTubeLogic
    {
        public static string GetRiskLevels(List<string> input)
        {
            var heightMap = GetHeigthMap(input);
            int topEdge = 0;
            int bottomEdge = input.Count;
            int leftEdge = 0;
            int rightEdge = input[0].Length;

            long sumLowestPoints = 0L;
            for (int line = 0; line < bottomEdge; line++)
            {
                for (int position = 0; position < rightEdge; position++)
                {
                    // first check up
                    if (!(line - 1 < topEdge) && heightMap[line - 1, position] <= heightMap[line, position])
                        continue;
                    // check right
                    if (!(position + 1 >= rightEdge) && heightMap[line, position + 1] <= heightMap[line, position])
                        continue;
                    // check down
                    if (!(line + 1 >= bottomEdge) && heightMap[line + 1, position] <= heightMap[line, position])
                        continue;
                    // check left
                    if (!(position - 1 < leftEdge) && heightMap[line, position - 1] <= heightMap[line, position])
                        continue;

                    sumLowestPoints += 1 + heightMap[line, position];
                }
            }

            return sumLowestPoints.ToString();
        }

        private static int[,] GetHeigthMap(List<string> input)
        {
            int[,] heightmMap = new int[input.Count, input[0].Length];
            for (int line = 0; line < input.Count; line++)
            {
                for (int position = 0; position < input[line].Length; position++)
                {
                    heightmMap[line, position] = int.Parse(input[line][position].ToString());
                }
            }
            return heightmMap;
        }

        public static string GetBasinSize(List<string> input)
        {
            List<List<string>> heigths = new();
            input.ForEach(i =>
            {
                List<string> line = new();
                i.ToList().ForEach(j =>
                {
                    if (j == '9')
                        line.Add("*");
                    else
                        line.Add(j.ToString());
                });
                heigths.Add(line);
            });

            int topEdge = 0;
            int bottomEdge = input.Count;
            int leftEdge = 0;
            int rightEdge = input[0].Length;
            int counter = 0;

            for (int line = 0; line < heigths.Count; line++)
            {
                for (int position = 0; position < heigths[0].Count; position++)
                {
                    if (line >= topEdge && line < bottomEdge && position >= leftEdge && position < rightEdge)
                    {
                        string heigth = heigths[line][position];
                        if (line == 0)
                        {
                            if (heigth == "*")
                            {
                                if (position - 1 >= leftEdge && heigths[line][position - 1] != "*")
                                    counter++;
                            }
                            else
                                heigths[line][position] = counter.ToString();
                        }
                        else
                        {
                            if (heigth != "*")
                            {
                                var left = position - 1 >= leftEdge
                                    ? heigths[line][position - 1]
                                    : string.Empty;
                                var above = heigths[line - 1][position];
                                var right = position + 1 < rightEdge
                                    ? heigths[line][position + 1]
                                    : String.Empty;
                                if (!above.Equals("*"))
                                    heigths[line][position] = above.ToString();
                                else if (!left.Equals("*") && left.Count() != 0)
                                    heigths[line][position] = left.ToString();
                                else if (right.Equals("*"))
                                {
                                    counter++;
                                    heigths[line][position] = counter.ToString();
                                }
                                else
                                {
                                    bool foundBasin = false;
                                    int cnt = position + 1;
                                    while (!foundBasin && cnt < rightEdge)
                                    {
                                        var next = heigths[line - 1][cnt];
                                        if (next != "*")
                                        {
                                            if (heigths[line][cnt].Equals("*"))
                                                break;
                                            foundBasin = true;
                                            heigths[line][position] = next;
                                        }
                                        cnt++;
                                    }
                                    if (!foundBasin)
                                    {
                                        counter++;
                                        heigths[line][position] = counter.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var countByOccurence = heigths.SelectMany(height => height)
                .ToList().GroupBy(h => h)
                .ToDictionary(h => h.Key, h => h.Count());
            var highestThree = countByOccurence
                .Where(h => h.Key != "*")
                .OrderByDescending(h => h.Value)
                .Take(3)
                .ToList();
            var size = highestThree.Select(h => h.Value).Aggregate(1, (x, y) => x * y);
            return size.ToString();

            // guessed 541476, too low
        }
    }
}
