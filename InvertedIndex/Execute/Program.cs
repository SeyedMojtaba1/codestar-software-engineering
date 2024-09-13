using System;
using System.IO;
using System.Resources;
using System.Collections.Generic;


namespace InvertedIndex
{
    static class Program
    {
        static void Main(string[] args)
        {
            ReadtxtFile rtf = new ReadtxtFile();
            Dictionary<int, List<string>> doc = new Dictionary<int, List<string>>();
            doc = rtf.ExtarcAllFiles(args[0]);

            string[] arg = new string[args.Length-1];
            for(int i = 0 ; i < args.Length-1 ; i++)
            {
                arg[i] = args[i+1];
            }
            ExecuteSearch exse = new ExecuteSearch();
            exse.Execute(doc, arg);
        }
    }
}