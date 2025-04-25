namespace InvertedIndex
{
    using Interfaces;

    internal class DictionaryFromFilesMaker : IDictionaryFromFilesMaker
    {
        private readonly IIndexMaker _indexMaker;

        public DictionaryFromFilesMaker(IIndexMaker indexMaker)
        {
            _indexMaker = indexMaker;
        }

        public Dictionary<int, List<string>> MakeDictionaryFromFiles(Dictionary<int, List<string>> dictionaryOfFiles, int key, string text)
        {
            string[] arrText = _indexMaker.splitDocument(text);

            var indexes = new List<string>();
            foreach (var item in arrText)
            {
                indexes.Add(item);
            }

            dictionaryOfFiles.Add(key, indexes);

            return dictionaryOfFiles;
        }
    }
}