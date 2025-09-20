using System;
using System.Linq; // Required for SequenceEqual
using Xunit;
using InvertedIndex;

namespace InvertedIndex.Test
{
    public class WordsMustExistTest
    {
        [Fact]
        public void Test1()
        {
            var wordsMustExist = new WordsMustExist();

            //Initialize the dictionary
            Dictionary<int, List<string>> doc = new Dictionary<int, List<string>>();
            doc.Add(1, new List<string> { "apple", "banana", "cherry" });
            doc.Add(2, new List<string> { "dog", "cat", "elephant" });
            doc.Add(3, new List<string> { "red", "green", "blue" });
            doc.Add(4, new List<string> { "car", "bike", "bus" });

            //Initialize the List
            List<string> arg = new List<string>();
            arg.Add("apple");
            arg.Add("cherry");

            var result = wordsMustExist.SearchInDocs(doc, arg);
            List<int> excepted = new List<int>();
            excepted.Add(1);

            Assert.Equal(result, excepted);
        }
    }
}