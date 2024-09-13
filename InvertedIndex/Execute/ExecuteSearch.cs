namespace InvertedIndex{
    class ExecuteSearch{
        public void Execute(Dictionary<int, List<string>> doc, string[] args)
        {
            List<int> contain = new List<int>();
            ClassificationOfArguments temp = new ClassificationOfArguments();
            Dictionary<int, List<string>> arguments = temp.ClassificationArgs(args);

            MustExist mex = new MustExist();
            contain = mex.SearchInDocs(doc, arguments[0]);

            AtLeastExistOne aleo = new AtLeastExistOne();
            contain = aleo.SearchInRemDocs(doc, contain, arguments[1]);

            MustNotExist mnex = new MustNotExist();
            contain = mnex.SearchInRemDocs(doc, contain, arguments[2]);

            foreach(var item in contain)
            {
                System.Console.WriteLine("Document " + item);
            }
        }
    }
}