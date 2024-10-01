namespace InvertedIndex{
    interface IExecuteSearch
    {
        public void Execute(Dictionary<int, List<string>> doc, string[] args);
    }

    class ExecuteSearch : IExecuteSearch
    {
        private readonly IClassificationOfArguments _classificationOfArguments;
        private readonly IWordsMustExist _wordsMustExist;
        private readonly IWordsAtLeastExistOne _wordsAtLeastExistOne;
        private readonly IWordsMustNotExist _wordsMustNotExist;

        public ExecuteSearch(IClassificationOfArguments classificationOfArguments, IWordsMustExist wordsMustExist, IWordsAtLeastExistOne wordsAtLeastExistOne, IWordsMustNotExist wordsMustNotExist)
        {
            _classificationOfArguments = classificationOfArguments;
            _wordsMustExist = wordsMustExist;
            _wordsAtLeastExistOne = wordsAtLeastExistOne;
            _wordsMustNotExist = wordsMustNotExist;
        }
        public void Execute(Dictionary<int, List<string>> doc, string[] args)
        {
            var contain = new List<int>();
            var arguments = _classificationOfArguments.ClassificationArgs(args);

            contain = _wordsMustExist.SearchInDocs(doc, arguments[0]);
            contain = _wordsAtLeastExistOne.SearchInRemDocs(doc, contain, arguments[1]);
            contain = _wordsMustNotExist.SearchInRemDocs(doc, contain, arguments[2]);

            foreach(var item in contain)
            {
                System.Console.WriteLine("Document " + item);
            }
        }
    }
}