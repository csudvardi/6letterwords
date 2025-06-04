namespace SixLetterWords.Services
{
    public interface IWordCombinationSeeker
    {
        List<string> ValidCombinations { get; set; }
        void FindValidCombinations(List<string> currentCombination, int currentLength, HashSet<string> allWords);
    }
    public class WordCombinationSeeker : IWordCombinationSeeker
    {
        private const int TargetLengthOfCombinedWord = 6;
        public List<string> ValidCombinations { get; set; } = new List<string>();

        public void FindValidCombinations(List<string> currentCombination, int currentLength, HashSet<string> allWords)
        {
            if (currentLength == TargetLengthOfCombinedWord)
            {
                var combinedWord = string.Join("", currentCombination);
                if (IsValidCombinedWord(combinedWord, currentCombination.Count, allWords))
                {
                    ValidCombinations.Add($"{string.Join("+", currentCombination)} = {combinedWord}");
                }
                return;
            }

            foreach (var word in allWords)
            {
                if (currentCombination.Contains(word)) continue; // Avoid duplicates
                if (currentLength + word.Length > TargetLengthOfCombinedWord) continue; // Skip if exceeds length
                currentCombination.Add(word);
                FindValidCombinations(currentCombination, currentLength + word.Length, allWords);
                currentCombination.RemoveAt(currentCombination.Count - 1); // Backtrack
            }
        }

        private bool IsValidCombinedWord(string combinedWord, int amountOfWordsCombined, HashSet<string> allWords)
        {
            return allWords.Contains(combinedWord) && amountOfWordsCombined > 1;
        }
    }
}
