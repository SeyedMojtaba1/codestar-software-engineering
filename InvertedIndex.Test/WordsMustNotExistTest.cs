using System;
using System.Linq; // Required for SequenceEqual
using Xunit;
using InvertedIndex;

namespace InvertedIndex.Test
{
    public class WordsMustNotExistTest
    {
        [Fact]
        public void Test1()
        {
            var wordsMustNotExist = new WordsMustNotExist();

            //Initialize the dictionary
            Dictionary<int, List<string>> doc = new Dictionary<int, List<string>>();
            doc.Add(1, new List<string> { "apple", "banana", "cherry" });
            doc.Add(2, new List<string> { "dog", "cat", "elephant" });
            doc.Add(3, new List<string> { "red", "green", "blue" });
            doc.Add(4, new List<string> { "car", "bike", "bus" });

            //Initialize the List
            List<int> contain = new List<int>();
            contain.Add(1);
            contain.Add(3);

            //Initialize the List
            List<string> arg = new List<string>();
            arg.Add("dog");
            arg.Add("car");

            var result = wordsMustNotExist.SearchInRemDocs(doc, contain, arg);
            List<int> excepted = new List<int>();
            excepted.Add(1);
            excepted.Add(3);

            Assert.Equal(result, excepted);
        }
    }
}