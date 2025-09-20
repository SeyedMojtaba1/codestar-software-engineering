namespace InvertedIndex
{
    internal class WordsMustExistChecker : DocumentSearchHandler
    {
        private List<string> arguments;

        public WordsMustExistChecker(List<string> args)
        {
            arguments = args;
        }

        public override Dictionary<int, List<string>> Handle(Dictionary<int, List<string>> doc)
        {
            var contain = new Dictionary<int, List<string>>();
            var argSet = new HashSet<string>(arguments);

            foreach (var item in doc)
            {
                var itemSet = new HashSet<string>(item.Value);
                var commenItems = itemSet.Intersect(argSet).Count();

                if (commenItems == arguments.Count)
                {
                    contain.Add(item.Key, item.Value);
                }
            }

            return next.Handle(contain);
        }
    }
}