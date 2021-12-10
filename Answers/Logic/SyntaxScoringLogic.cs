namespace Answers.Logic
{
    public static class SyntaxScoringLogic
    {
        public static string GetCorruptedLines(List<string> input)
        {
            long syntaxErrorScore = 0L;
            input.ForEach(line =>
            {
                if (!line.Parse(out List<char> closings, out char error))
                    syntaxErrorScore += error.GetErrorScore();
            });

            return syntaxErrorScore.ToString();
        }

        public static string GetAutoCompleteScore(List<string> input)
        {
            List<long> scores = new();
            input.ForEach(line =>
            {
                List<char> closings = new();
                if (line.Parse(out List<char> openings, out char error))
                {
                    if (openings.Count > 0)
                    {
                        for (int i = 0; i < openings.Count; i++)
                        {
                            closings.Add(openings[i].ClosesChunk());
                        }
                    }
                    closings.Reverse();
                    scores.Add(GetScore(closings));
                }
            });
            var orderedScores = scores.OrderBy(s => s).ToList();
            var middle = scores.Count / 2;
            return (orderedScores[middle]).ToString();
        }

        private static long GetErrorScore(this char error)
        {
            return error == ')' ? 3
                    : error == ']' ? 57
                    : error == '}' ? 1197
                    : 25137;
        }

        private static long GetScore(List<char> closings)
        {
            long score = 0L;
            for (int i = 0; i < closings.Count; i++)
            {
                score *= 5;
                score += closings[i].GetScore();
            }
            return score;
        }

        private static long GetScore(this char closing)
        {
            return closing == ')' ? 1
                    : closing == ']' ? 2
                    : closing == '}' ? 3
                    : 4;
        }

        private static bool Parse(this string line, out List<char> openings, out char error)
        {
            openings = new();
            for (int i = 0; i < line.Length; i++)
            {
                var character = line[i];
                if (character.IsOpeningCharacter())
                    openings.Add(character);
                else
                {
                    var openingCharacter = openings.LastOrDefault('*');
                    if (openingCharacter == '*' || openingCharacter != character.OpensChunk())
                    {
                        error = character;
                        return false;
                    }
                    else
                    {
                        openings.RemoveAt(openings.Count - 1);
                    }
                }
            }
            error = '*';
            return true;
        }

        private static bool IsOpeningCharacter(this char character)
        {
            return character == '(' || character == '[' || character == '{' || character == '<';
        }

        private static char OpensChunk(this char closing)
        {
            if (closing == ')') return '(';
            if (closing == ']') return '[';
            if (closing == '}') return '{';
            else return '<';
        }

        private static char ClosesChunk(this char closing)
        {
            if (closing == '(') return ')';
            if (closing == '[') return ']';
            if (closing == '{') return '}';
            else return '>';
        }
    }
}
