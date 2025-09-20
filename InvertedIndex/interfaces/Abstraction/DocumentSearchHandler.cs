interface IDocumentSearchHandler
{
    Dictionary<int, List<string>> Handle(Dictionary<int, List<string>> doc);
}