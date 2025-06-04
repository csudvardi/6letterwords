namespace SixLetterWords.Services
{
    public interface ITxtFileProcessor
    {
        HashSet<string> ConvertFileContentToHashSet();
        Dictionary<int, List<string>> GroupWordsByLength(HashSet<string> words, int targetLength);
    }
    public class TxtFileProcessor : ITxtFileProcessor
    {
        private const string FileName = "input.txt";

        public HashSet<string> ConvertFileContentToHashSet()
        {
            return
            [
                ..File.ReadAllLines(GetFilePath())
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => line.Trim())
            ];
        }

        private static string GetFilePath()
        {
            return Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, FileName);
        }

        public Dictionary<int, List<string>> GroupWordsByLength(HashSet<string> words, int targetLength)
        {
            Dictionary<int, List<string>> wordsByLength = new();

            foreach (var word in words)
            {
                var length = word.Length;
                if (length > targetLength) continue;

                if (!wordsByLength.ContainsKey(length))
                {
                    wordsByLength[length] = new List<string>();
                }
                wordsByLength[length].Add(word);
            }

            return wordsByLength;
        }
    }
}
