namespace InvertedIndex
{

    interface IReadtxtFile
    {
        public Dictionary<int, List<string>> ExtarctAllFiles(string path);
    }

    interface IReaderFile
    {
        public string ReaderFile(string path);
    }

    interface IGetAllFile
    {
        public string[] GetAllFile(string path);
    }
    internal class ReadtxtFile : IReadtxtFile, IReaderFile, IGetAllFile
    {
        private readonly IMakeDictionary _makeDictionary;
        public ReadtxtFile(IMakeDictionary makeDictionary)
        {
            _makeDictionary = makeDictionary;
        }
        public Dictionary<int, List<string>> ExtarctAllFiles(string path)
        {
            var doc = new Dictionary<int, List<string>>();
            string[] allFiles = GetAllFile(path);

            int i = 1;
            foreach (var item in allFiles)
            {
                string temp = ReaderFile(item);
                doc = _makeDictionary.docToDic(doc, i, temp);
                i++;
            }

            return doc;
        }
        public string ReaderFile(string path)
        {
            string text = File.ReadAllText(path).ToUpper();
            return text;
        }


        public string[] GetAllFile(string path)
        {
            string[] allFiles = Directory.GetFiles(path);
            return allFiles;
        }
    }
}