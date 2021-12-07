using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answers.Logic
{
    public class CrabSubmarineLogic
    {
        public static string GetFuelConsumption(List<string> input)
        {
            var crabs = input[0].Split(',').Select(f => int.Parse(f)).ToList();
            var lowestFuelConsumption = long.MaxValue;

            for (int i = 0; i < crabs.Count; i++)
            {
                var fuelConsumption = 0L;
                for (int j = 0; j < crabs.Count; j++)
                {
                    fuelConsumption += Math.Abs(crabs[i]-crabs[j]);
                }
                if (fuelConsumption < lowestFuelConsumption)
                    lowestFuelConsumption = fuelConsumption;
            }

            return lowestFuelConsumption.ToString();
        }

        public static string GetCumulativeFuelConsumption(List<string> input)
        {
            var crabs = input[0].Split(',').Select(f => int.Parse(f)).ToList();
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
