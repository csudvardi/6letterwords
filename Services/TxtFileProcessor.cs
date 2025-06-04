namespace SixLetterWords.Services
{
    public interface ITxtFileProcessor
    {
        HashSet<string> ConvertFileContentToHashSetFromPath(string filePath);
        Dictionary<int, List<string>> GroupWordsByLength(HashSet<string> words);
    }
    public class TxtFileProcessor : ITxtFileProcessor
    {
        public HashSet<string> ConvertFileContentToHashSetFromPath(string filePath)
        {
            return
            [
                ..File.ReadAllLines(filePath)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => line.Trim())
            ];
        }

        public Dictionary<int, List<string>> GroupWordsByLength(HashSet<string> words)
        {
            Dictionary<int, List<string>> wordsByLength = new();

            foreach (var word in words)
            {
                var length = word.Length;
                if (length > 6) continue;

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
