using System.Text;

namespace Answers.Logic
{
    public class DiagnosticsLogic
    {
        public static string GetPowerConsumption(List<string> report)
        {
            StringBuilder gamma = new();
            StringBuilder epsilon = new();

            for (int position = 0; position < report[0].Length; position++)
            {
                var bits = new List<char>();
                for (int line = 0; line < report.Count; line++)
                {
                    bits.Add(report[line][position]);
                }
                gamma.Append(GetBit(bits, isCommon: true));
                epsilon.Append(GetBit(bits, isCommon: false));
            }

            return GetDiagnostic(gamma.ToString(), epsilon.ToString());
        }

        private static char GetBit(List<char> bits, bool isCommon)
        {
            var grouped = bits
                .GroupBy(x => x)
                .Select(group => new { Bit = group.Key, Count = group.Count() });

            if (grouped.Select(g => g.Count).Distinct().Count() == 1)
                grouped = grouped.OrderBy(g => g.Bit);
            else
                grouped = grouped.OrderBy(g => g.Count);

            if (isCommon)
                return grouped.Last().Bit;
            
            return grouped.First().Bit;
        }

        private static string GetDiagnostic(string x, string y)
        {
            return (Convert.ToInt32(x, 2) * Convert.ToInt32(y, 2)).ToString();
        }

        public static string GetLifeSupportRating(List<string> report)
        {
            var oxygen = GetRating(report, 0, isCommon: true);
            var co2 = GetRating(report, 0, isCommon: false);
            return GetDiagnostic(oxygen, co2);
        }

        private static string GetRating(List<string> report, int position, bool isCommon)
        {
            var binaries = GetCorrespondingBinaries(report, position, GetBit(report, position, isCommon));
            if (binaries.Count == 1)
                return binaries[0];
            else
                return GetRating(binaries, ++position, isCommon);
        }

        private static char GetBit(List<string> binaries, int position, bool isCommon)
        {
            var bits = binaries.Select(x => x[position]).ToList();
            return GetBit(bits, isCommon);
        }

        private static List<string> GetCorrespondingBinaries(List<string> binaries, int position, char bit)
        {
            return binaries.Where(x => x[position] == bit).ToList();
        }
    }
}
