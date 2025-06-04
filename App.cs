using SixLetterWords.Services;

namespace SixLetterWords
{
    public class App(
        ITxtFileProcessor txtFileProcessor,
        IWordCombinationSeeker wordCombinationSeeker,
        IWordPrinter wordPrinter)
    {
        public void Run()
        {
            var allWords = GetWords();
            wordCombinationSeeker.FindValidCombinations(new List<string>(), 0, allWords);
            wordPrinter.PrintWords(wordCombinationSeeker.ValidCombinations);
        }

        //private void GroupWordsByLength()
        //{
        //    Dictionary<int, List<string>> wordsByLength = txtFileProcessor.GroupWordsByLength(_allWords, TargetLength);
        //}

        private HashSet<string> GetWords()
        {
            return txtFileProcessor.ConvertFileContentToHashSet();
        }
    }
}
