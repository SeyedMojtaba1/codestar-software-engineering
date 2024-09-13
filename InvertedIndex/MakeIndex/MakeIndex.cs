namespace InvertedIndex{
    class MakeIndex
    {
        public string[] splitDocument(string value)
        {
            string[] splitedValue = value.Split(" ");
            return splitedValue;
        }
    }
}