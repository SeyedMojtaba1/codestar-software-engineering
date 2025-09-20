using System;
using System.IO;
using System.Resources;
using System.Collections.Generic;
using System.Reflection;


namespace InvertedIndex
{
    using Interfaces;

    static class Program
    {
        static void Main(string[] args)
        {
            IIndexMaker indexMaker = new IndexMaker();
            IDictionaryFromFilesMaker dictionaryFromFilesMaker = new DictionaryFromFilesMaker(indexMaker);
            IFilesToDictionaryParser filesToDictionaryParser = new FilesToDictionaryParser(dictionaryFromFilesMaker);
            var doc = new Dictionary<int, List<string>>();
            doc = filesToDictionaryParser.ParseFilesToDictionary(args[0]);

            var arg = args.Skip(1).Take(args.Length);

            ITypeArgumentsClassifier typeArgumentsClassifier = new TypeArgumentsClassifier();

            var inputArgumentsSearcher = new InputArgumentsSearcher(typeArgumentsClassifier);
            var result = inputArgumentsSearcher.Execute(doc, arg.ToArray());

            IPrinter resultPrinter = new Printer();
            resultPrinter.Print(result);
        }
    }
}