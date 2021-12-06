using Answers.Logic;
using Answers.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answers
{
    internal class DaySixPartOne : IAnswer
    {
        public string Get()
        {
            var input = InputReader.ReadFile("day6part1.txt");
            return LaternFishBreedingLogic.GetNumberOfFish(input, 80);
        }

        public int GetMenuOrder()
        {
            return 11;
        }

        public string GetMenuTitle()
        {
            return "Day Six Part One";
        }
    }
}
