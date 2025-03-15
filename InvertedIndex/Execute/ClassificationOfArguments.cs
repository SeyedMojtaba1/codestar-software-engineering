namespace InvertedIndex
{
    interface IClassificationOfArguments
    {
        public Dictionary<int, List<string>> ClassificationArgs(string[] args);
    }
    internal class ClassificationOfArguments : IClassificationOfArguments
    {
        public Dictionary<int, List<string>> ClassificationArgs(string[] args)
        {
            var arguments = new Dictionary<int, List<string>>();
            var argMust = new List<string>();
            var argAtLeast = new List<string>();
            var argNot = new List<string>();

            foreach (var item in args)
            {
                string temp = item.ToUpper();
                if (temp[0] == '+')
                {
                    argAtLeast.Add(temp);
                }
                else if (temp[0] == '-')
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