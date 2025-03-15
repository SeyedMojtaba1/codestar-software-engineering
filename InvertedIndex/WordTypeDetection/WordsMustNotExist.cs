namespace InvertedIndex
{
    interface IWordsMustNotExist
    {
        public List<int> SearchInRemDocs(Dictionary<int, List<string>> doc, List<int> contain, List<string> arg);
    }

    internal class WordsMustNotExist : IWordsMustNotExist
    {
        public List<int> SearchInRemDocs(Dictionary<int, List<string>> doc, List<int> contain, List<string> arg)
        {
            if (arg.Count == 0)
            {
                return contain;
            }

            foreach (var item in contain)
            {
                int check = 0;
                foreach (var item2 in arg)
                {
                    if (CheckExist(doc, item, item2))
                    {
                        check++;
                    }
                }
                if (check > 0)
                {
                    contain.Remove(item);
                }
            }

            return contain;
        }

        bool CheckExist(Dictionary<int, List<string>> doc, int item, string item2)
        {
            return doc[item].ToArray().Contains<string>(item2);
        }
    }
}