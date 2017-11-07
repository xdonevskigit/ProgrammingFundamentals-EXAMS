using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuitTwo
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"([\D]+)([\d]+)";
            
            string input = Console.ReadLine().ToUpper();
            var match = Regex.Matches(input, pattern);
            StringBuilder sb = new StringBuilder();
            string word = "";
            foreach (Match item in match)
            {
                word = item.Groups[1].Value;                
                    sb.Append(word);          
            }
            int count = sb.ToString().Distinct().Count();
            if (count == 54)
            {
                count--;
            }
            Console.WriteLine("Unique symbols used: " + count);
            sb.Clear();
            foreach (Match item in match)
            {
                word = item.Groups[1].Value;
                int repeat = int.Parse(item.Groups[2].Value);
                for (int i = 0; i < repeat; i++)
                {
                    
                    sb.Append(word);
                }
            }
            Console.WriteLine(sb);
            
        }
    }
}
