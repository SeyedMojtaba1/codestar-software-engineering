namespace InvertedIndex
{
    internal class AtLeastOneWordMustExistChecker : DocumentSearchHandler
    {
        private List<string> arguments;

        public AtLeastOneWordMustExistChecker(List<string> args)
        {
            arguments = args;
        }

        public override Dictionary<int, List<string>> Handle(Dictionary<int, List<string>> document)
        {
            if (arguments.Count == 0)
            {
                return next.Handle(document);
            }

            var contain = new Dictionary<int, List<string>>();
            var argSet = new HashSet<string>(arguments);

            foreach (var item in document)
            {
                var itemSet = new HashSet<string>(item.Value);
                var commenItems = itemSet.Intersect(argSet).Count();

                if (commenItems > 0)
                {
                    contain.Add(item.Key, item.Value);
                }
            }

            return next.Handle(contain);
        }
    }
}