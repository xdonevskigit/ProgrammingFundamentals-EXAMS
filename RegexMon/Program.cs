using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexMon
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsPattern = @"([A-Za-z]+-[A-Za-z]+)";
            string otherSymbols = @"([^A-Za-z-]+)";
            var wordList = new List<string>();
            var otherSymbolList = new List<string>();

            string input = Console.ReadLine();

            while (Regex.Match(input, wordsPattern).Success || Regex.Match(input, otherSymbols).Success)
            {
                string didimon = Regex.Match(input, otherSymbols).ToString();
                
                if (didimon.Length != 0)
                {
                    Console.WriteLine(didimon);
                    int didimonIndex = input.IndexOf(didimon);
                    input = input.Remove(0, didimon.Length + didimonIndex);
                }
                else
                {
                    return;
                }
                
                string bojomon = Regex.Match(input, wordsPattern).ToString();
                
                if (bojomon.Length != 0)
                {
                    Console.WriteLine(bojomon);
                    int bojomonIndex = input.IndexOf(bojomon);
                    input = input.Remove(0, bojomon.Length + bojomonIndex);
                }
                else
                {
                    return;
                }                          
            }
        }
    }
}
