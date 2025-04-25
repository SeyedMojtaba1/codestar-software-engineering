namespace Interfaces
{
    interface IFilesToDictionaryParser
    {
        public Dictionary<int, List<string>> ParseFilesToDictionary(string path);
    }
}