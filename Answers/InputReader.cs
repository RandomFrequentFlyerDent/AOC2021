﻿namespace Answers
{
    public class InputReader
    {
        public static List<string> ReadFile(string fileName)
        {
            List<string> values = new();
            string line;
            string fileLocation = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input", fileName));

            StreamReader file = new(fileLocation);
            while ((line = file.ReadLine()) != null)
            {
                values.Add(line);
            }

            return values;
        }
    }
}