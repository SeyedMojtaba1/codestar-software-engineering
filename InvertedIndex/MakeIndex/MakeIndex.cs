namespace InvertedIndex{
    interface IMakeIndex
    {
        public string[] splitDocument(string value);
    }
    class MakeIndex : IMakeIndex
    {
        public string[] splitDocument(string value)
        {
            string[] splitedValue = value.Split(" ");
            return splitedValue;
        }
    }
}