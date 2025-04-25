namespace InvertedIndex
{
    using Interfaces;

    internal class IndexMaker : IIndexMaker
    {
        public string[] splitDocument(string value)
        {
            string[] splitedValue = value.Split(" ");
            return splitedValue;
        }
    }
}