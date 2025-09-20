namespace InvertedIndex
{
    using Interfaces;

    internal class InputArgumentsSearcher : IInputArgumentsSearcher
    {
        private readonly ITypeArgumentsClassifier _typeArgumentsClassifier;

        public InputArgumentsSearcher(ITypeArgumentsClassifier typeArgumentsClassifier)
        {
            _typeArgumentsClassifier = typeArgumentsClassifier;
        }
        public Dictionary<int, List<string>> Execute(Dictionary<int, List<string>> doc, string[] args)
        {
            if (args[0] == null)
            {
                Console.WriteLine("Error: Invalid Input!");
                Environment.Exit(0);
            }
            var arguments = _typeArgumentsClassifier.TypeClassifier(args);

            var mustExistHandler = new WordsMustExistChecker(arguments[0]);
            var atLeastOneHandler = new AtLeastOneWordMustExistChecker(arguments[1]);
            var mustNotExistHandler = new WordsMustNotExistChecker(arguments[2]);

            mustExistHandler.SetNext(atLeastOneHandler);
            atLeastOneHandler.SetNext(mustNotExistHandler);

            var contain = atLeastOneHandler.Handle(doc);

            return contain;
        }
    }
}