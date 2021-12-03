using System.Text;

namespace Answers.Logic
{
    public class PowerConsumptionLogic
    {
        public static string GetPowerConsumption(List<string> input)
        {
            StringBuilder gamma = new();
            StringBuilder epsilon = new();

            for (int position = 0; position < input[0].Length; position++)
            {
                var bits = new List<char>();
                for (int row = 0; row < input.Count; row++)
                {
                    bits.Add(input[row][position]);
                }
                gamma.Append(GetBit(bits, true));
                epsilon.Append(GetBit(bits, false));
            }

            return (Convert.ToInt32(gamma.ToString(), 2) * Convert.ToInt32(epsilon.ToString(), 2)).ToString();
        }

        public static char GetBit(List<char> bits, bool IsMostCommon)
        {
            var zeroes = bits.Count(b => b == '0');
            var ones = bits.Count(b => b == '1');
            if (zeroes > ones && IsMostCommon)
                return '0';
            if (ones > zeroes && !IsMostCommon)
                return '0';
            if (ones == zeroes && !IsMostCommon)
                return '0';

            return '1';
        }
    }
}
