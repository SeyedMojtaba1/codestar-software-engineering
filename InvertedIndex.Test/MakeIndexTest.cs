using System;
using System.Linq; // Required for SequenceEqual
using Xunit;
using InvertedIndex;

namespace InvertedIndex.Test
{
    public class MakeIndexTest
    {
        [Theory]
        [InlineData("salam seyed chetori?", new string[] { "salam", "seyed", "chetori?" }, true)]
        [InlineData("salam seyed chetori?", new string[] { "salam", "seyed", "chetori?", "" }, false)]
        [InlineData("salam seyed", new string[] { "salam", "seyed" }, true)]
        [InlineData("salam seye chetori?", new string[] { "salam", "seyed", "chetori?" }, false)]
        public void Test1(string input, string[] expectedArray, bool expectedResult)
        {
            // Arrange
            var makeIndex = new MakeIndex();

            // Act
            string[] result = makeIndex.splitDocument(input);

            // Assert
            bool arraysAreEqual = result.SequenceEqual(expectedArray); // Compare arrays
            Assert.Equal(expectedResult, arraysAreEqual); // Check if the comparison matches the expected result
        }
    }
}