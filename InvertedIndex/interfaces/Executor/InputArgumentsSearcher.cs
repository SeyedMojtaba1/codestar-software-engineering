interface IInputArgumentsSearcher
{
    public Dictionary<int, List<string>> Execute(Dictionary<int, List<string>> doc, string[] args);
}