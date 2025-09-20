namespace InvertedIndex
{
    using Interfaces;

    internal class FilesToDictionaryParser : IFilesToDictionaryParser
    {
        private readonly IDictionaryFromFilesMaker _dictionaryFromFilesMaker;
        public FilesToDictionaryParser(IDictionaryFromFilesMaker dictionaryFromFilesMaker)
        {
            _dictionaryFromFilesMaker = dictionaryFromFilesMaker;
        }
        public Dictionary<int, List<string>> ParseFilesToDictionary(string path)
        {
            var document = new Dictionary<int, List<string>>();
            IFileNamesExtracter fileNamesExtracter = new FileNamesExtracter();
            ITextFileReader textFileReader = new TextFileReader();

            string[] allFiles = fileNamesExtracter.ExtractFileNames(path);

            int i = 1;
            foreach (var item in allFiles)
            {
                string temp = textFileReader.ReadTextFile(item);
                document = _dictionaryFromFilesMaker.MakeDictionaryFromFiles(document, i, temp);
                i++;
            }

            return document;
        }
    }
}