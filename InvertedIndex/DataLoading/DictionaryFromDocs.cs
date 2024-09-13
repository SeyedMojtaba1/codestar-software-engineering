namespace InvertedIndex{
    class MakeDictionary
    {
        public Dictionary<int, List<string>> docToDic(Dictionary<int, List<string>> dirOfDoc, int key, string text)
        {
            MakeIndex temp = new MakeIndex();
            string[] arrText = temp.splitDocument(text);

            List<string> indexes = new List<string>();
            foreach (var item in arrText)
            {
                indexes.Add(item);
            }
            
            dirOfDoc.Add(key, indexes);
            
            return dirOfDoc;
        }
    }
}