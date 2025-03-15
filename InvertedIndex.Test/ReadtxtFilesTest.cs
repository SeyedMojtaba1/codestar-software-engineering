using System;
using System.Linq;
using Xunit;
using InvertedIndex;

namespace InvertedIndex.Test
{
    public class ReadtxtFilesTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var makeIndex = new MakeIndex();
            var makeDictionary = new MakeDictionary(makeIndex);
            var readtxtFile = new ReadtxtFile(makeDictionary);

            // Act
            var result = readtxtFile.ExtarctAllFiles("E:\\codestar-software-engineering\\InvertedIndex.Test\\TestFiles\\");

            var doc = new Dictionary<int, List<string>>();
            doc.Add(1, new List<string> { ">THIS", "WOULDN'T", "HAPPEN", "TO", "BE", "THE", "SAME", "THING", "AS", "CHIGGERS" });
            doc.Add(2, new List<string> { "CONVENTION", "WILL", "BE", "HELD", "AT", "THE", "SALT", "PALACE", "CONVENTION" });

            // Assert
            Assert.Equal(doc, result);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var makeIndex = new MakeIndex();
            var makeDictionary = new MakeDictionary(makeIndex);
            var readtxtFile = new ReadtxtFile(makeDictionary);

            // Act
            var result = readtxtFile.ReaderFile("E:\\codestar-software-engineering\\InvertedIndex.Test\\TestFiles\\58044");
            var expectedResult = "convention will be held at the Salt Palace Convention";
            expectedResult = expectedResult.ToUpper();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var makeIndex = new MakeIndex();
            var makeDictionary = new MakeDictionary(makeIndex);
            var readtxtFile = new ReadtxtFile(makeDictionary);

            // Act
            var result = readtxtFile.GetAllFile("E:\\codestar-software-engineering\\InvertedIndex.Test\\TestFiles\\");
            string[] expectedResult = new string[] { "E:\\codestar-software-engineering\\InvertedIndex.Test\\TestFiles\\58043", "E:\\codestar-software-engineering\\InvertedIndex.Test\\TestFiles\\58044" };

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}