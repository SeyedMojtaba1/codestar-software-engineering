using System.Text.Json;

namespace InvertedIndex{
    class makeSerializeJsonString
    {
        public string makeJsonString(Dictionary<int, List<string>> doc)
        {
            string serializedIndex = JsonSerializer.Serialize(doc);
            return serializedIndex;
        }
    }
}