using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> uniqueChars = new List<string>();
            string pattern = "([^0-9]+)([0-9]+)";
            var matches = Regex.Matches(input, pattern);
            List<string> result = new List<string>();

            foreach (Match item in matches)
            {
                var symbols = item.Groups[1].Value.ToUpper();
                var num = int.Parse(item.Groups[2].Value);
                result.Add(ReturnRepeatSymbols(symbols, num));

                char[] charArr = new char[symbols.Length];
                charArr = symbols.ToCharArray();
                for (int i = 0; i < charArr.Length; i++)
                {
                   // if (!uniqueChars.Contains(charArr[i].ToString()))
                   // {
                        uniqueChars.Add(charArr[i].ToString());
                   // }
                    
                }
            }
            List<string> distinct = uniqueChars.Distinct().ToList();

                Console.WriteLine($"Unique symbols used: {distinct.Count}");            

            Console.WriteLine(String.Join("",result));
            
        }
        public static String ReturnRepeatSymbols(string symbols, int numbers)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; i++)
            {
                sb.Append(symbols);
            }
            return sb.ToString();
        }
    }
}
