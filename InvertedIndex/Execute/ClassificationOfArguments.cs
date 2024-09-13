namespace InvertedIndex{
    class ClassificationOfArguments
    {
        public Dictionary<int, List<string>> ClassificationArgs(string[] args)
        {
            Dictionary<int, List<string>> arguments = new Dictionary<int, List<string>>();
            List<string> argMust = new List<string>();
            List<string> argAtLeast = new List<string>();
            List<string> argNot = new List<string>();

            foreach(var item in args)
            {
                string temp = item.ToUpper();
                if(temp[0] == '+')
                {
                    argAtLeast.Add(temp);
                }
                else if(temp[0] == '-')
                {
                    argNot.Add(temp);
                }
                else
                {
                    argMust.Add(temp);
                }
            }

            arguments.Add(0, argMust);
            arguments.Add(1, argAtLeast);
            arguments.Add(2, argNot);

            return arguments;
        }
    }
}