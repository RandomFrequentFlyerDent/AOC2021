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
            var heightMap = GetHeigthMap(input);

            // Imma gonna have to think about this
            
            return string.Empty;
        }
    }
}
