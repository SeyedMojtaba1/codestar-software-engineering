using System;
using System.Linq;
using Xunit;
using InvertedIndex;

namespace InvertedIndex.Test
{
    public class MakeDictionaryTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            IMakeIndex makeIndex = new MakeIndex();
            var makeDictionary = new MakeDictionary(makeIndex);
            Dictionary<int, List<string>> dicOfDoc = new Dictionary<int, List<string>>();

            Dictionary<int, List<string>> expectedResult = new Dictionary<int, List<string>>{
                {0, new List<string> {"In", "the", "bustling", "city,", "neon", "lights"}}
                };

            // Act
            Dictionary<int, List<string>> result = makeDictionary.docToDic(dicOfDoc, 0, "In the bustling city, neon lights");

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}