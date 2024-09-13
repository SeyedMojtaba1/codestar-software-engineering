namespace InvertedIndex{
    class MustExist
    {
        public List<int> SearchInDocs(Dictionary<int, List<string>> doc, List<string> arg)
        {
            List<int> contain = new List<int>();

            foreach(var item in doc)
            {
                int check = 0;
                foreach(var item2 in arg.ToArray())
                {
                    if(CheckExist(item, item2))
                    {
                        check++;
                    }
                }
                if(CheckEqContainCount(check, arg))
                {
                    contain.Add(item.Key);
                }
            }   

            return contain;
        }

        bool CheckEqContainCount(int check, List<string> arg)
        {
            return check == arg.Count;
        }

        bool CheckExist(KeyValuePair<int, List<string>> item, string item2)
        {
            return item.Value.ToArray().Contains<string>(item2);
        }
    }
}