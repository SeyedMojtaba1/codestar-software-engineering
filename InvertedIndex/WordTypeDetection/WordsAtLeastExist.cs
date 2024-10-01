namespace InvertedIndex{
    interface IWordsAtLeastExistOne
    {
        public List<int> SearchInRemDocs(Dictionary<int, List<string>> doc, List<int> contain, List<string> arg);
    }

    class WordsAtLeastExistOne : IWordsAtLeastExistOne
    {
        public List<int> SearchInRemDocs(Dictionary<int, List<string>> doc, List<int> contain, List<string> arg)
        {
            if(arg.Count == 0)
            {
                return contain;
            }

            var result = new List<int>();
            foreach(var item in contain)
            {
                foreach(var item2 in arg)
                {
                    if(CheckExist(doc, item, item2))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        bool CheckExist(Dictionary<int, List<string>> doc, int item, string item2)
        {
            return doc[item].ToArray().Contains<string>(item2);
        }
    }
}