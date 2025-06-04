namespace SixLetterWords.Services
{
    public interface IWordPrinter
    {
        void PrintWords(List<string> words);
    }
    public class WordPrinter : IWordPrinter
    {
        public void PrintWords(List<string> words)
        {
            if (words.Count == 0)
            {
                Console.WriteLine("No valid combinations found.");
                return;
            }

            foreach (var combination in words)
            {
                Console.WriteLine(combination);
            }
        }
    }
}
