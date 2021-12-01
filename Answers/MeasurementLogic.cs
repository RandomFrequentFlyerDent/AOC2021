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

        public static string NumberOfDepthIncreasesByThreeMeasurementsWindow(List<string> input)
        {
            var measurements = input.Select(m => long.Parse(m)).ToList();
            List<string> threeWindowMeasurements = new();

            for (int measurement = 0; measurement < measurements.Count - 2; measurement++)
            {
                long window = measurements[measurement] + measurements[measurement + 1] + measurements[measurement + 2];
                threeWindowMeasurements.Add(window.ToString());
            }
            return NumberOfDepthIncreases(threeWindowMeasurements);
        }
    }
}
