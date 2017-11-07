using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> fileInfo = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                fileInfo.Add(input);
            }
            string filter = Console.ReadLine();
            string[] filterToken = filter.Split(new char[] { ' ' }       
            , StringSplitOptions.RemoveEmptyEntries).ToArray();
            string filterFileExt = "." + filterToken[0];
            string filterStartRoot = filterToken[filterToken.Length - 1] + "\\";

            List<string> sortedList = new List<string>();
            var fileNameAndSize = new Dictionary<string, long>();
            foreach (var item in fileInfo)
            {
                var splittingList = item.Split(';');
                var tokens = item.Split(new char[] { '\\', ';' });
                string fileName = tokens[tokens.Length - 2];
                long fileSize = long.Parse(splittingList[1]);
                if (splittingList[0].StartsWith(filterStartRoot) && splittingList[0].EndsWith(filterFileExt))
                {
                    fileNameAndSize[fileName] = fileSize;
                }
            }
            foreach (var item in fileNameAndSize.OrderByDescending(f => f.Value).ThenBy(f => f.Key))
            {
                Console.WriteLine(item.Key + " - " + item.Value + " KB");
            }
            if (fileNameAndSize.Count() == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
