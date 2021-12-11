using Answers.Model;
using System.Text;

namespace Answers.Logic
{
    public class DumboOctopusLogic
    {
        public static string GetFlashes(List<string> input)
        {
            List<Octopus> octopi = new();
            for (int line = 0; line < input.Count; line++)
            {
                for (int position = 0; position < input[0].Length; position++)
                {
                    octopi.Add(new Octopus { EnergyLevel = int.Parse(input[line][position].ToString()), Position = int.Parse(line.ToString() + position.ToString()) });
                }
            }

            long flashes = 0L;
            int numberOfSteps = 2;

            for (int i = 0; i < numberOfSteps; i++)
            {
                // increase energy level of each octopus with 1
                octopi.ForEach(o => o.EnergyLevel++);
                // increase energy surrounding octopi if energy higher than 9 and flash
                flashes = GetFlashes(octopi, flashes);
                // reset flashed octopi
                octopi.Where(o => o.HasAlreadyFlashed).ToList().ForEach(o => { o.HasAlreadyFlashed = false; o.EnergyLevel = 0; });
            }

            return Draw(octopi); //flashes.ToString();
        }

        private static long GetFlashes(List<Octopus> octopi, long flashes)
        {
            var readyToFlash = octopi.Where(o => !o.HasAlreadyFlashed && o.EnergyLevel > 9).ToList();
            for (int position = 0; position < readyToFlash.Count; position++)
            {
                var octopus = readyToFlash[position];
                flashes++;
                octopus.HasAlreadyFlashed = true;
                octopi.Where(o => octopus.GetPositionsSurroundingOctopi().Contains(o.Position)).ToList()
                    .ForEach(o => { o.EnergyLevel++; });
            }

            if (octopi.Any(o => !o.HasAlreadyFlashed && o.EnergyLevel > 9))
                return GetFlashes(octopi, flashes);
            return flashes;
        }

        private static string Draw(List<Octopus> octopi)
        {
            StringBuilder sb = new();
            for (int position = 0; position < octopi.Count; position++)
            {
                var octopus = octopi.Single(o => o.Position == position);
                if (position % 10 == 0)
                    sb.AppendLine();
                sb.Append(octopus.EnergyLevel);
            }

            return sb.ToString();
        }
    }
}
