namespace InvertedIndex{
    class ReadtxtFile
    {
        public Dictionary<int, List<string>> ExtarcAllFiles(string path)
        {
            Dictionary<int, List<string>> doc = new Dictionary<int, List<string>>();
            string[] allFiles = GetAllFile(path);

            int i = 1;
            foreach(var item in allFiles)
            {
                string temp = ReaderFile(item);
                MakeDictionary md = new MakeDictionary();
                doc = md.docToDic(doc, i, temp);
                i++;
            }
            
            return doc;
        }
        string ReaderFile(string path)
        {
            string text = File.ReadAllText(path).ToUpper();
            return text;
        }


        string[] GetAllFile(string path)
        {
            string[] allFiles = Directory.GetFiles(path);
            return allFiles;
        }
    }
}