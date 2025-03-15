namespace InvertedIndex
{
    interface IMakeDictionary
    {
        public Dictionary<int, List<string>> docToDic(Dictionary<int, List<string>> dirOfDoc, int key, string text);
    }
    internal class MakeDictionary : IMakeDictionary
    {
        private readonly IMakeIndex _makeIndex;

        public MakeDictionary(IMakeIndex makeIndex)
        {
            _makeIndex = makeIndex;
        }

        public Dictionary<int, List<string>> docToDic(Dictionary<int, List<string>> dicOfDoc, int key, string text)
        {
            string[] arrText = _makeIndex.splitDocument(text);

            var indexes = new List<string>();
            foreach (var item in arrText)
            {
                indexes.Add(item);
            }

            dicOfDoc.Add(key, indexes);

            return dicOfDoc;
        }
    }
}