using System;
using System.IO;
using System.Resources;
using System.Text.Json;
using System.Collections.Generic;


namespace InvertedIndex
{
    class ReadtxtFile
    {
        public Dictionary<int, List<string>> ExtarcAllFiles(string path)
        {
            Dictionary<int, List<string>> doc = new Dictionary<int, List<string>>();
            string[] allFiles = GetAllFile(path);

            for(int i = 0 ; i < allFiles.Length ; i++)
            {
                string temp = ReaderFile(allFiles[i]);
                MakeDictionary md = new MakeDictionary();
                doc = md.docToDic(doc, i, temp);
            }
            
            return doc;
        }
        string ReaderFile(string path)
        {
            string text = File.ReadAllText(path).ToUpper();
            return text;
        }


        string[] GetAllFile(string path)
        {
            string[] allFiles = Directory.GetFiles(path);
            return allFiles;
        }
    }

    class MakeDictionary
    {
        public Dictionary<int, List<string>> docToDic(Dictionary<int, List<string>> dirOfDoc, int key, string text)
        {
            MakeIndex temp = new MakeIndex();
            string[] arrText = temp.splitDocument(text);

            List<string> indexes = new List<string>();
            foreach (var item in arrText)
            {
                indexes.Add(item);
            }
            
            dirOfDoc.Add(key, indexes);
            
            return dirOfDoc;
        }
    }
    
    class makeSerializeJsonString
    {
        public string makeJsonString(Dictionary<int, List<string>> doc)
        {
            string serializedIndex = JsonSerializer.Serialize(doc);
            return serializedIndex;
        }
    }

    class MakeIndex
    {
        public string[] splitDocument(string value)
        {
            string[] splitedValue = value.Split(" ");
            return splitedValue;
        }
    }

    class MustExist
    {
        public List<int> SearchInDocs(Dictionary<int, List<string>> doc, List<string> arg)
        {
            List<int> contain = new List<int>();

            foreach(var item in doc)
            {
                int check = 0;
                foreach(var item2 in arg.ToArray())
                {
                    if(CheckExist(item, item2))
                    {
                        check++;
                    }
                }
                if(CheckEqContainCount(check, arg))
                {
                    contain.Add(item.Key);
                }
            }   

            return contain;
        }

        bool CheckEqContainCount(int check, List<string> arg)
        {
            return check == arg.Count;
        }

        bool CheckExist(KeyValuePair<int, List<string>> item, string item2)
        {
            return item.Value.ToArray().Contains<string>(item2);
        }
    }

    class AtLeastExistOne
    {
        public List<int> SearchInRemDocs(Dictionary<int, List<string>> doc, List<int> contain, List<string> arg)
        {
            if(arg.Count == 0)
            {
                return contain;
            }

            List<int> result = new List<int>();
            foreach(var item in contain)
            {
                foreach(var item2 in arg)
                {
                    if(CheckExist(doc, item, item2))
                    {
                        result.Add(item);
                        continue;
                    }
                }
            }

            return result;
        }

        bool CheckExist(Dictionary<int, List<string>> doc, int item, string item2)
        {
            return doc[item].ToArray().Contains<string>(item2);
        }
    }

    class MustNotExist
    {
        public List<int> SearchInRemDocs(Dictionary<int, List<string>> doc, List<int> contain, List<string> arg)
        {
            if(arg.Count == 0)
            {
                return contain;
            }
            
            foreach(var item in contain)
            {
                int check = 0;
                foreach(var item2 in arg)
                {
                    if(CheckExist(doc, item, item2))
                    {
                        check++;
                    }
                }
                if(check > 0)
                {
                    contain.Remove(item);
                }
            }

            return contain;
        }

        bool CheckExist(Dictionary<int, List<string>> doc, int item, string item2)
        {
            return doc[item].ToArray().Contains<string>(item2);
        }
    }

    class ExecuteSearch{
        public void Execute(Dictionary<int, List<string>> doc, string[] args)
        {
            List<int> contain = new List<int>();
            ClassificationOfArguments temp = new ClassificationOfArguments();
            Dictionary<int, List<string>> arguments = temp.ClassificationArgs(args);

            MustExist mex = new MustExist();
            contain = mex.SearchInDocs(doc, arguments[0]);

            AtLeastExistOne aleo = new AtLeastExistOne();
            contain = aleo.SearchInRemDocs(doc, contain, arguments[1]);

            MustNotExist mnex = new MustNotExist();
            contain = mnex.SearchInRemDocs(doc, contain, arguments[2]);

            foreach(var item in contain)
            {
                System.Console.WriteLine("Document " + item);
            }
        }
    }

    class ClassificationOfArguments
    {
        public Dictionary<int, List<string>> ClassificationArgs(string[] args)
        {
            Dictionary<int, List<string>> arguments = new Dictionary<int, List<string>>();
            List<string> argMust = new List<string>();
            List<string> argAtLeast = new List<string>();
            List<string> argNot = new List<string>();

            foreach(var item in args)
            {
                string temp = item.ToUpper();
                if(temp[0] == '+')
                {
                    argAtLeast.Add(temp);
                }
                else if(temp[0] == '-')
                {
                    argNot.Add(temp);
                }
                else
                {
                    argMust.Add(temp);
                }
            }

            arguments.Add(0, argMust);
            arguments.Add(1, argAtLeast);
            arguments.Add(2, argNot);

            return arguments;
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            string txtDirPath = "./EnglishData";

            ReadtxtFile rtf = new ReadtxtFile();
            Dictionary<int, List<string>> doc = new Dictionary<int, List<string>>();
            doc = rtf.ExtarcAllFiles(txtDirPath);

            ExecuteSearch exse = new ExecuteSearch();
            exse.Execute(doc, args);
        }
    }
}