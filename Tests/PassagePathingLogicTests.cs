using Answers.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class PassagePathingLogicTests
    {
        [TestCaseSource(typeof(Paths), nameof(Paths.Caves))]
        public string GetPaths(List<string> input, bool withMultipleSmallCaveVisit)
        {
            return PassagePathingLogic.GetPaths(input, withMultipleSmallCaveVisit);
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
            }, false).SetName("Small - simple").Returns("10");

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
            }, false).SetName("Medium - simple").Returns("19");

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
            }, false).SetName("Large - simple").Returns("226");

            yield return
                new TestCaseData(new List<string>{
                "start-A",
                "start-b",
                "A-c",
                "A-b",
                "b-d",
                "A-end",
                "b-end"
            }, true).SetName("Small - multiple").Returns("36");

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
            }, true).SetName("Medium - multiple").Returns("103");

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
            }, true).SetName("Large - multiple").Returns("3509");
        }
    }
}
