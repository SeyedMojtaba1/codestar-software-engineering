using System;
using System.Linq;
using Xunit;
using InvertedIndex;

namespace InvertedIndex.Test
{
    public class ClassificationOfArgumentsTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var classificationOfArguments = new ClassificationOfArguments();
            string[] arguments = { "salam", "+seyed", "-chetori?" };
            Dictionary<int, List<string>> exceptedResult = new Dictionary<int, List<string>>{
                { 0, new List<string> {"SALAM"} },
                { 1, new List<string> {"+SEYED"} },
                { 2, new List<string> {"-CHETORI?"} }
            };

            // Act
            var result = classificationOfArguments.ClassificationArgs(arguments);

            // Assert
            Assert.Equal(result, exceptedResult);
        }
    }
}