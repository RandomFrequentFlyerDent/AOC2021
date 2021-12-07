namespace Answers.Logic
{
    public class LaternFishBreedingLogic
    {
        public static string GetNumberOfFish(List<string> input, int numberOfDays)
        {
            var fish = input[0].Split(',').Select(f => int.Parse(f)).GroupBy(f => f).ToDictionary(f => f.Key, f => (long)f.Count());
            return GetFishByAge(fish, numberOfDays).Sum(f => f.Value).ToString();
        }

        private static Dictionary<int, long> GetFishByAge(Dictionary<int, long> fishByAge, int numberOfDays)
        {
            for (int i = 0; i <= 8; i++)
            {
                if (!fishByAge.ContainsKey(i))
                    fishByAge.Add(i, 0);
            }

            int day = 1;
            while (day <= numberOfDays)
            {
                long previousCount = 0L;
                for (int i = 8; i >= 0; i--)
                {
                    long currentCount = fishByAge[i];
                    if (i == 0)
                    {
                        fishByAge[8] = currentCount;
                        fishByAge[6] += currentCount;
                    }
                    fishByAge[i] = previousCount;
                    previousCount = currentCount;
                }
                day++;
            }

            return fishByAge;
        }
    }
}
