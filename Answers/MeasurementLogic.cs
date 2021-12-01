namespace Answers
{
    public class MeasurementLogic
    {
        public static string NumberOfDepthIncreases(List<string> input)
        {
            var measurements = input.Select(m => long.Parse(m)).ToList();
            long count = 0;
            for (int measurement = 1; measurement < measurements.Count; measurement++)
            {
                if (measurements[measurement] > measurements[measurement - 1])
                    count++;
            }

            return count.ToString();
        }
    }
}
