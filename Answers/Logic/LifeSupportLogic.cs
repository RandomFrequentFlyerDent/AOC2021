namespace Answers.Logic
{
    public class LifeSupportLogic
    {
        public static string GetRating(List<string> input)
        {
            var oxygen = GetRating(input, 0, true);
            var co2 = GetRating(input, 0, false);
            return (Convert.ToInt32(oxygen.ToString(), 2) * Convert.ToInt32(co2.ToString(), 2)).ToString();
        }

        private static string GetRating(List<string> input, int position, bool IsOxygen)
        {
            var binaries = GetCorrespondingBinaries(input, position, GetBit(input, position, IsOxygen));
            if (binaries.Count == 1)
                return binaries[0];
            else
                return GetRating(binaries, ++position, IsOxygen);
        }

        private static char GetBit(List<string> binaries, int position, bool IsOxygen)
        {
            var bits = binaries.Select(x => x[position]).ToList();
            return PowerConsumptionLogic.GetBit(bits, IsOxygen);
        }

        private static List<string> GetCorrespondingBinaries(List<string> binaries, int position, char bit)
        {
            return binaries.Where(x => x[position] == bit).ToList();
        }
    }
}
