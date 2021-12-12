using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class PassagePathingLogicTests
    {
        [TestCaseSource(typeof(Paths), nameof(Paths.Caves))]
        public string GetPaths(List<string> input)
        {
            return PassagePathingLogic.GetPaths(input);
        }

    }

    public class Paths
    {
        public static IEnumerable<TestCaseData> Caves()
        {
            yield return
                new TestCaseData(new List<string>{
                "start-A",
                "start-b",
                "A-c",
                "A-b",
                "b-d",
                "A-end",
                "b-end"
            }).SetName("Small").Returns("10");

            yield return
                new TestCaseData(new List<string>
            {
                "dc-end",
                "HN-start",
                "start-kj",
                "dc-start",
                "dc-HN",
                "LN-dc",
                "HN-end",
                "kj-sa",
                "kj-HN",
                "kj-dc"
            }).SetName("Medium").Returns("19");

            yield return new TestCaseData
            (new List<string>
            {
                "fs-end",
                "he-DX",
                "fs-he",
                "start-DX",
                "pj-DX",
                "end-zg",
                "zg-sl",
                "zg-pj",
                "pj-he",
                "RW-he",
                "fs-DX",
                "pj-RW",
                "zg-RW",
                "start-pj",
                "he-WI",
                "zg-he",
                "pj-fs",
                "start-RW"
            }).SetName("Large").Returns("226");
        }
    }
}
