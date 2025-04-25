namespace Interfaces
{
    interface ITypeArgumentsClassifier
    {
        public Dictionary<int, List<string>> TypeClassifier(string[] args);
    }
}
