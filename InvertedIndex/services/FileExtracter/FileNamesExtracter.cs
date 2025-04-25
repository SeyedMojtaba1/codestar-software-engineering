namespace InvertedIndex
{
    using Interfaces;

    internal class FileNamesExtracter : IFileNamesExtracter
    {
        public string[] ExtractFileNames(string path)
        {
            string[] allFiles = Directory.GetFiles(path);
            return allFiles;
        }
    }
}