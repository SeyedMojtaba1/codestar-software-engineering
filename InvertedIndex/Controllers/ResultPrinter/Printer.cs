namespace InvertedIndex
{
    using Interfaces;

    internal class Printer : IPrinter
    {
        public Printer() { }
        public void Print(Dictionary<int, List<string>> result)
        {
            foreach (var item in result)
            {
                System.Console.WriteLine("Document " + item.Key);
            }
        }
    }
}