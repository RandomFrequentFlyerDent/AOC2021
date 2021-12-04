using Answers.Model;

namespace Answers.Logic
{
    public class BingoLogic
    {
        public static string GetFinalScore(List<string> input, bool squidWin)
        {
            List<int> numbersCalled = input[0].Split(',').Select(n => int.Parse(n)).ToList();
            List<BingoCard> bingoCards = GetBingoCards(input);
            (int number, BingoCard bingoCard) = squidWin
                ? GetLastWinningBingoCard(numbersCalled, 0, bingoCards)
                : GetWinningBingoCard(numbersCalled, bingoCards);
            var sumOfUnMarkedNumbers = bingoCard.GetUnmarkedNumbers().Sum(n => n);

            return (sumOfUnMarkedNumbers * number).ToString();
        }

        private static List<BingoCard> GetBingoCards(List<string> input)
        {
            List<BingoCard> bingoCards = new();
            BingoCard bingoCard = new();
            int row = 0;

            for (int line = 2; line < input.Count; line++)
            {
                if (input[line] == "")
                {
                    if (bingoCard.Slots.Count > 0)
                        bingoCards.Add(bingoCard);
                    bingoCard = new BingoCard();
                    row = 0;
                }
                else
                {
                    var numbers = input[line]
                        .Trim()
                        .Replace("  ", " 0")
                        .Split(' ')
                        .Select(number => int.Parse(number))
                        .ToList();
                    bingoCard.SetSlots(numbers, row);
                    row++;
                }
            }

            if (bingoCard.Slots.Count > 0)
                bingoCards.Add(bingoCard);

            return bingoCards;
        }

        private static (int, BingoCard) GetWinningBingoCard(List<int> numbersCalled, List<BingoCard> bingoCards)
        {
            for (int call = 0; call < numbersCalled.Count; call++)
            {
                var number = numbersCalled[call];
                for (int card = 0; card < bingoCards.Count; card++)
                {
                    var bingocard = bingoCards[card];
                    if (bingocard.IsBingo(number))
                        return (number, bingocard);
                }
            }

            return (0, new BingoCard());
        }

        private static (int, BingoCard) GetLastWinningBingoCard(List<int> numbers, int position, List<BingoCard> bingoCards)
        {
            List<BingoCard> nonWinningCards = new();
            for (int card = 0; card < bingoCards.Count; card++)
            {
                var number = numbers[position];
                var bingoCard = bingoCards[card];
                if (!bingoCard.IsBingo(number))
                {
                    nonWinningCards.Add(bingoCard);
                }
            }
            if (nonWinningCards.Count == 0)
                return (numbers[position], bingoCards[0]);

            return GetLastWinningBingoCard(numbers, ++position, nonWinningCards);
        }
    }
}
