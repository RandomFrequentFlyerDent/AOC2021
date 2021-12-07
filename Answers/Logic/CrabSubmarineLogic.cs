namespace Answers.Logic
{
    public class CrabSubmarineLogic
    {
        public static string GetFuelConsumption(List<string> input, bool getCumulative)
        {

            var crabs = input[0].Split(',').Select(f => int.Parse(f)).ToList();

            if (getCumulative)
                return GetCumulativeFuelConsumption(crabs);

            var lowestFuelConsumption = long.MaxValue;

            for (int i = 0; i < crabs.Count; i++)
            {
                var fuelConsumption = 0L;
                for (int j = 0; j < crabs.Count; j++)
                {
                    fuelConsumption += Math.Abs(crabs[i] - crabs[j]);
                }
                if (fuelConsumption < lowestFuelConsumption)
                    lowestFuelConsumption = fuelConsumption;
            }

            return lowestFuelConsumption.ToString();
        }

        private static string GetCumulativeFuelConsumption(List<int> crabs)
        {
            var lowestPosition = crabs.Min();
            var highestPosition = crabs.Max();
            var lowestFuelConsumption = long.MaxValue;

            for (int i = lowestPosition; i <= highestPosition; i++)
            {
                var fuelConsumption = 0L;
                for (int j = 0; j < crabs.Count; j++)
                {
                    var distance = Math.Abs(crabs[j] - i);
                    fuelConsumption += distance * (distance + 1) / 2;
                }
                if (fuelConsumption < lowestFuelConsumption)
                    lowestFuelConsumption = fuelConsumption;
            }

            return lowestFuelConsumption.ToString();
        }
    }
}
