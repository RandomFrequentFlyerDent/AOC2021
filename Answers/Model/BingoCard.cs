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
            for (int position = 0; position < 5; position++)
            {
                var isBingo = Slots.Where(slot => slot.Col == position).All(slot => slot.Called);
                if (isBingo) return true;
                isBingo = Slots.Where(slot => slot.Row == position).All(slot => slot.Called);
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
