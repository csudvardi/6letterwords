using SixLetterWords.Services;

namespace SixLetterWords
{
    public class App(ITxtFileProcessor txtFileProcessor)
    {
        private HashSet<string> _allWords = new HashSet<string>();
        private Dictionary<int, List<string>> _wordsByLength = new();
        private readonly List<string> _validCombinations = new List<string>();

        private const string FileName = "input.txt";
        private const int TargetLength = 6;

        public void Run()
        {
            LoadWords();
            FindValidCombinations([], 0);
            PrintValidCombinations();
        }

        private void LoadWords()
        {
            _allWords = txtFileProcessor.ConvertFileContentToHashSetFromPath(GetFilePath());
            _wordsByLength = txtFileProcessor.GroupWordsByLength(_allWords);
        }

        private static string GetFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
        }

        private void FindValidCombinations(List<string> currentCombination, int currentLength)
        {
            if (currentLength == TargetLength)
            {
                var combinedWord = string.Join("", currentCombination);
                if (IsValidCombinedWord(combinedWord, currentCombination.Count))
                {
                    _validCombinations.Add($"{string.Join("+", currentCombination)} = {combinedWord}");
                }
                return;
            }

            foreach (var word in _allWords)
            {
                if (currentCombination.Contains(word)) continue; // Avoid duplicates
                if (currentLength + word.Length > TargetLength) continue; // Skip if exceeds length
                currentCombination.Add(word);
                FindValidCombinations(currentCombination, currentLength + word.Length);
                currentCombination.RemoveAt(currentCombination.Count - 1); // Backtrack
            }
        }

        private bool IsValidCombinedWord(string combinedWord, int amountOfWordsCombined)
        {
            return _allWords.Contains(combinedWord) && amountOfWordsCombined > 1;
        }

        private void PrintValidCombinations()
        {
            if (_validCombinations.Count == 0)
            {
                Console.WriteLine("No valid combinations found.");
                return;
            }

            foreach (var combination in _validCombinations)
            {
                Console.WriteLine(combination);
            }
        }
    }
}
