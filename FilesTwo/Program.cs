using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileInfo = new Dictionary<string, Dictionary<string, long>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] fileTokens = input.Split(new char[] { ';', '\\' }
                , StringSplitOptions.RemoveEmptyEntries).ToArray();
                string rootFolder = fileTokens[0];
                long size = long.Parse(fileTokens[fileTokens.Length - 1]);
                string fileName = fileTokens[fileTokens.Length - 2];

                if (!fileInfo.ContainsKey(fileName))
                {
                    fileInfo.Add(fileName, new Dictionary<string, long>());
                    fileInfo[fileName].Add(rootFolder, size);
                }
                else if (!fileInfo[fileName].ContainsKey(rootFolder))
                {
                    fileInfo[fileName].Add(rootFolder, size);
                }
                else
                {
                    fileInfo[fileName][rootFolder] = size;
                }
            }
            string[] searchingFiles = Console.ReadLine().Split().ToArray();
            string extension = searchingFiles[0];
            string folderRoot = searchingFiles[2];
            var resultDict = new Dictionary<string, long>();
            foreach (var kvp in fileInfo)
            {
                int index = kvp.Key.LastIndexOf('.');
                string fileExtension = kvp.Key.Substring(index + 1, kvp.Key.Length - 1 - index);

                foreach (var rootSize in kvp.Value)
                {
                    if (extension == fileExtension && folderRoot == rootSize.Key)
                    {                      
                        resultDict.Add(kvp.Key, rootSize.Value);
                    }
                }
            }
            if (resultDict.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
            foreach (var kvp in resultDict.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} KB");
            }
        }
    }
}
