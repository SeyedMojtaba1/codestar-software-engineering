namespace InvertedIndex
{
    using Interfaces;

    internal class TextFileReader : ITextFileReader
    {
        public string ReadTextFile(string path)
        {
            string text = File.ReadAllText(path).ToUpper();
            return text;
        }
    }
}