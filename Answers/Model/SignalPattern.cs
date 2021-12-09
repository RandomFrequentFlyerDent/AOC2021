using System.Text;

namespace Answers.Model
{
    public class SignalPattern
    {
        public string[] Pattern { get; set; } = new string[10];
        public string[] Output { get; set; } = new string[4];

        public string[] GetEasyNumbersOutput()
        {
            return Output
                .Where(o => o.Length == 2 || o.Length == 3 || o.Length == 4 || o.Length == 7)
                .ToArray();
        }

        public int GetCode()
        {
            StringBuilder code = new();
            List<SevenSegmentDisplay> displayOptions = new();

            foreach (var display in Pattern)
                displayOptions.Add(new SevenSegmentDisplay(display));

            var oneDisplay = displayOptions.Where(d => d.NumberOnDisplay == 1).First();
            var fourDisplay = displayOptions.Where(d => d.NumberOnDisplay == 4).First();
            var sevenDisplay = displayOptions.Where(d => d.NumberOnDisplay == 7).First();
            var eigthDisplay = displayOptions.Where(d => d.NumberOnDisplay == 8).First();

            var fiveRenders = displayOptions.Where(d => d.Pattern.Length == 5).ToList(); // 2, 3 and 5
            var sixRenders = displayOptions.Where(d => d.Pattern.Length == 6).ToList(); // 0, 6 and 9

            char top = '&';
            char topLeft = '&';
            char topRight = '&';
            char middle = '&';
            char bottomLeft = '&';
            char bottomRight = '&';
            char bottom = '&';

            // By filtering out the pattern of display with number 1 from display with number 7 we find the top character
            top = sevenDisplay.GetRemainingCharacter(oneDisplay.Pattern.ToList());

            // By comparing the pattern of display with number 1 with all displays which take 5 characters to render
            // we find that only 3 contains the entire code of 1
            var threeDisplay = fiveRenders.Where(d => d.ContainsPattern(oneDisplay.Pattern.ToList())).First();
            threeDisplay.NumberOnDisplay = 3;

            // Of all the displays which take 6 characters to render only 9 has all the same characters as 3 plus 1 extra character; top left
            var nineDisplay = sixRenders.Where(d => d.ContainsPattern(threeDisplay.Pattern.ToList())).First();
            nineDisplay.NumberOnDisplay = 9;
            topLeft = nineDisplay.GetRemainingCharacter(threeDisplay.Pattern.ToList());

            // By filtering out the pattern of display with number 1 and the top left character from display with number 4
            // we find the middle character
            var patternToCheck = oneDisplay.Pattern.ToList();
            patternToCheck.Add(topLeft);
            middle = fourDisplay.GetRemainingCharacter(patternToCheck);

            // By comparing the top, left top and middle to all the displays which take 5 characters to render
            // and whose numebr to display is not yet known (we've found 3), we find that only display with number 5 has all three
            // and therefore the other display will show number 6
            patternToCheck.Clear();
            patternToCheck.AddRange(new List<char> { top, topLeft, middle });
            var fiveDisplay = fiveRenders.Where(d => !d.NumberOnDisplay.HasValue).Where(d => d.ContainsPattern(patternToCheck)).First();
            fiveDisplay.NumberOnDisplay = 5;
            var twoDisplay = fiveRenders.Where(d => !d.NumberOnDisplay.HasValue).First();
            twoDisplay.NumberOnDisplay = 2;

            // Now that we know which display will show 5 we can determine the top right character by filtering out its pattern
            // from display with number 9
            topRight = nineDisplay.GetRemainingCharacter(fiveDisplay.Pattern.ToList());

            // Since we know top right we now also know bottom right because of display with number 1
            bottomRight = oneDisplay.GetRemainingCharacter(new List<char> { topRight });

            // Since all but one of the characters of the display with number 9 has been rendered we now know the bottom character
            bottom = nineDisplay.GetRemainingCharacter(new List<char> { top, topLeft, topRight, middle, bottomRight });

            // Since all but one of the characters of the display with number 9 has been rendered we now know the bottom left character
            bottomLeft = eigthDisplay.GetRemainingCharacter(nineDisplay.Pattern.ToList());

            // Everything should now be fully rendered
            displayOptions.Where(d => !d.NumberOnDisplay.HasValue).Where(d => !d.ContainsPattern(new List<char> { middle })).First().NumberOnDisplay = 0;
            displayOptions.Where(d => !d.NumberOnDisplay.HasValue).First().NumberOnDisplay = 6;

            foreach (var output in Output)
            {
                var number = displayOptions.Where(d => d.IsSameOutput(output)).First().NumberOnDisplay;
                code.Append(number);
            }

            return int.Parse(code.ToString());
        }
    }
}
