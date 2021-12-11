namespace Answers.Model
{
    public class Octopus
    {
        public int EnergyLevel { get; set; }
        public int Position { get; set; }
        public bool HasAlreadyFlashed { get; set; }

        public List<int> GetPositionsSurroundingOctopi()
        {
            List<int> positions = new();
            positions.Add(Position - 10); // up
            positions.Add(Position - 9); // up right
            positions.Add(Position + 1); // right
            positions.Add(Position + 11); // down right
            positions.Add(Position + 10); // down
            positions.Add(Position + 9); // down left
            positions.Add(Position - 1); // left
            positions.Add(Position - 11); // up left
            return positions.Where(p => p > -1).ToList();
        }
    }
}
