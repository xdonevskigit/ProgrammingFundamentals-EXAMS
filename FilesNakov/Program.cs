using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesNakov
{
class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<string> allFiles = new List<string>();
        for (int i = 0; i < count; i++)
        {
            allFiles.Add(Console.ReadLine());
        }
        string filter = Console.ReadLine();
        var filterTokens = filter.Split(new string[] { " in " }
        , StringSplitOptions.RemoveEmptyEntries).ToArray();
        var filterExt = "." + filterTokens[0];
        var filterRoot = filterTokens[1] + "\\";
        Dictionary<string, int> fileSize = new Dictionary<string, int>();
        foreach (var f in allFiles)
        {
            var tokens = f.Split(';');
            var size = int.Parse(tokens[1]);
            var pathPlusFileName = tokens[0];
                if (pathPlusFileName.StartsWith(filterRoot) && pathPlusFileName.EndsWith(filterExt))
                {

                var parts = pathPlusFileName.Split('\\');
                var fileName = parts[parts.Length - 1];
                fileSize[fileName] = size;
                }         
        }
        var outputSize = fileSize.ToArray().OrderByDescending(fs => fs.Value)
            .ThenBy(fs => fs.Key);
        foreach (var item in outputSize)
        {
            Console.WriteLine(item.Key + " - " + item.Value + " KB");
        }
        if (outputSize.Count() == 0)
        {
            Console.WriteLine("No");
        }
    }  
}  
}
