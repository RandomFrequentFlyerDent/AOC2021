namespace Answers.Logic
{
    public class SteeringLogic
    {
        public static string GetPosition(List<string> input)
        {
            long depth = 0;
            long distance = 0;

            input.ForEach(m =>
            {
                var splitInput = m.Split(' ');
                var direction = (Direction)Enum.Parse(typeof(Direction), splitInput[0]);
                var size = long.Parse(splitInput[1]);

                switch (direction)
                {
                    case Direction.forward:
                        distance += size;
                        break;
                    case Direction.down:
                        depth += size;
                        break;
                    case Direction.up:
                        depth -= size;
                        break;
                    default:
                        break;
                }
            });

            return (depth * distance).ToString();
        }

        public static string GetPositionWithAim(List<string> input)
        {
            long depth = 0;
            long distance = 0;
            long aim = 0;

            input.ForEach(m =>
            {
                var splitInput = m.Split(' ');
                var direction = (Direction)Enum.Parse(typeof(Direction), splitInput[0]);
                var size = long.Parse(splitInput[1]);

                switch (direction)
                {
                    case Direction.forward:
                        distance += size;
                        depth = depth + (aim * size);
                        break;
                    case Direction.down:
                        aim += size;
                        break;
                    case Direction.up:
                        aim -= size;
                        break;
                    default:
                        break;
                }
            });

            return (depth * distance).ToString();
        }

        private enum Direction
        {
            forward,
            down,
            up
        }
    }
}
