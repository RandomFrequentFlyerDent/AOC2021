namespace Answers.Logic
{
    public class LaternFishBreedingLogic
    {
        public static string GetNumberOfFish(List<string> input, int numberOfDays)
        {
            var fish = input[0].Split(',').Select(f => new Fish(f)).ToList();
            return GetFish(fish, 0, numberOfDays).Count.ToString();
        }

        private static List<Fish> GetFish(List<Fish> fish, int day, int numberOfDays)
        {
            List<Fish> expandedList = new();
            expandedList.AddRange(fish);
            fish.ForEach(f =>
            {
                if (f.Procreates())
                    expandedList.Add(new Fish("8"));
            });
            if (day == numberOfDays - 1) return expandedList;
            return GetFish(expandedList, ++day, numberOfDays);
        }

        internal class Fish
        {
            private int _state;

            public Fish(string state)
            {
                _state = int.Parse(state);
            }

            internal bool Procreates()
            {
                if (_state == 0)
                {
                    _state = 6;
                    return true;
                }
                _state--;
                return false;
            }
        }
    }
}
