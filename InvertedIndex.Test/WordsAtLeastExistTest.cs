using System;
using System.Linq;
using Xunit;
using InvertedIndex;
using InvertedIndex.Tests;

namespace InvertedIndex.Tests
{
    public class WordsAtLeastExistOneTest
    {
        [Theory]
        [InlineData(new int[] { 1, 3 }, new string[] { "apple" }, new int[] { 1 })]
        [InlineData(new int[] { 3 }, new string[] { "apple" }, new int[] { })]
        [InlineData(new int[] { 1, 2 }, new string[] { "apple", "cherry" }, new int[] { 1 })]
        [InlineData(new int[] { 1, 3 }, new string[] { "apple", "elderberry" }, new int[] { 1, 3 })]

        public void Test1(int[] con, string[] arg, int[] expected)
        {
            // Arrange
            var wordsAtLeastExistOne = new WordsAtLeastExistOne();
            Dictionary<int, List<string>> doc = new Dictionary<int, List<string>> {
            { 1, new List<string> { "apple", "banana", "orange" } },
            { 2, new List<string> { "banana", "date" } },
            { 3, new List<string> { "cherry", "elderberry" } },
            { 4, new List<string> { "fig", "grape" } }
        };

            var contain = con.ToList();
            var argument = arg.ToList();
            // Act
            List<int> result = wordsAtLeastExistOne.SearchInRemDocs(doc, contain, argument);

            // Assert
            Assert.Equal(expected.ToList(), result);
        }
    }
}