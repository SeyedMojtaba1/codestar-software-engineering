using System;
using System.IO;
using System.Resources;
using System.Collections.Generic;
using System.Reflection;


namespace InvertedIndex
{
    static class Program
    {
        static void Main(string[] args)
        {
            IMakeIndex makeIndex = new MakeIndex();
            IMakeDictionary makeDictionary = new MakeDictionary(makeIndex);
            var readtxtFile = new ReadtxtFile(makeDictionary);
            var doc = new Dictionary<int, List<string>>();
            doc = readtxtFile.ExtarctAllFiles(args[0]);

            var arg = args.Skip(1).Take(args.Length);

            IClassificationOfArguments classificationOfArguments = new ClassificationOfArguments();
            IWordsMustExist wordsMustExist = new WordsMustExist();
            IWordsAtLeastExistOne wordsAtLeastExistOne = new WordsAtLeastExistOne();
            IWordsMustNotExist wordsMustNotExist = new WordsMustNotExist();
            var executeSearch = new ExecuteSearch(classificationOfArguments, wordsMustExist, wordsAtLeastExistOne, wordsMustNotExist);
            executeSearch.Execute(doc, arg.ToArray());
        }
    }
}