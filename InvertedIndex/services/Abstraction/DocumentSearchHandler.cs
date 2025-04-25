namespace InvertedIndex
{
    using Interfaces;
    internal abstract class DocumentSearchHandler : IDocumentSearchHandler
    {
        protected IDocumentSearchHandler next;

        public void SetNext(DocumentSearchHandler nextHandler)
        {
            next = nextHandler;
        }

        public virtual Dictionary<int, List<string>> Handle(Dictionary<int, List<string>> doc)
        {
            return doc;
        }
    }
}