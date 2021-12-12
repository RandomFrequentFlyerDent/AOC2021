namespace Answers.Model
{
    public class Octopus
    {
        private readonly IEnumerable<int> _leftLine = new List<int> { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };
        private readonly IEnumerable<int> _rightLine = new List<int> { 9, 19, 29, 39, 49, 59, 69, 79, 89, 99 };
        public int EnergyLevel { get; set; }
        public int Position { get; set; }
        public bool HasAlreadyFlashed { get; set; }

        public List<int> GetPositionsSurroundingOctopi()
        {
            bool hasAboveNeighbor = !Enumerable.Range(0, 9).Contains(Position);
            bool hasDownNeighbor = !Enumerable.Range(90, 99).Contains(Position);
            bool hasLeftNeighbor = !_leftLine.Contains(Position);
            bool hasRightNeighbor = !_rightLine.Contains(Position);

            List<int> positions = new();
            if (hasAboveNeighbor)
                positions.Add(Position - 10); // up
            if (hasDownNeighbor)
                positions.Add(Position + 10); // down
            if (hasRightNeighbor)
                positions.Add(Position + 1); // right
            if (hasLeftNeighbor)
                positions.Add(Position - 1); // left
            if (hasAboveNeighbor && hasRightNeighbor)
                positions.Add(Position - 9); // up right
            if (hasAboveNeighbor && hasLeftNeighbor)
                positions.Add(Position - 11); // up left
            if (hasDownNeighbor && hasRightNeighbor)
                positions.Add(Position + 11); // down right
            if (hasDownNeighbor && hasLeftNeighbor)
                positions.Add(Position + 9); // down left
            return positions.ToList();
        }
    }
}
