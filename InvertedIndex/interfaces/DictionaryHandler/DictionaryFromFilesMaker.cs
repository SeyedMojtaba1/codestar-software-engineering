namespace Interfaces
{
    interface IDictionaryFromFilesMaker
    {
        public Dictionary<int, List<string>> MakeDictionaryFromFiles(Dictionary<int, List<string>> dictionaryOfFiles, int key, string text);
    }
}