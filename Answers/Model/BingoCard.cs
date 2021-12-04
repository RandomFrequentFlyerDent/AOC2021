namespace Answers.Model
{
    public class BingoCard
    {
        public List<Slot> Slots { get; set; } = new();

        public void SetSlots(List<int> numbers, int row)
        {
            int col = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                var number = numbers[i];
                Slots.Add(new Slot(number, row, col));
                col++;
            }
        }

        public List<int> GetUnmarkedNumbers()
        {
            return Slots.Where(slot => !slot.Called).Select(slot => slot.Number).ToList();
        }

        public bool IsBingo(int number)
        {
            Slots.ForEach(slot => slot.Check(number));
            return IsBingoOnRow() || IsBingoOnCol();
        }

        private bool IsBingoOnRow()
        {
            for (int row = 0; row < 5; row++)
            {
                var isBingo = Slots.Where(slot => slot.Row == row).All(slot => slot.Called);
                if (isBingo) return true;
            }
            return false;
        }

        private bool IsBingoOnCol()
        {
            for (int col = 0; col < 5; col++)
            {
                var isBingo = Slots.Where(slot => slot.Col == col).All(slot => slot.Called);
                if (isBingo) return true;
            }
            return false;
        }

        public class Slot
        {
            internal int Number { get; set; }
            internal int Row { get; set; }
            internal int Col { get; set; }
            internal bool Called { get; set; }

            internal Slot(int number, int row, int col)
            {
                if (row > 5)
                    throw new ArgumentException("A bingocard only has 5 rows");
                if (col > 5)
                    throw new ArgumentException("A bingocard only has 5 columns");

                Number = number;
                Row = row;
                Col = col;
            }

            internal void Check(int number)
            {
                if (number == Number)
                    Called = true;
            }
        }
    }
}
