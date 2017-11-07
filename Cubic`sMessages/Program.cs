using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cubic_sMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                               
                if (input == "Over!")
                {
                    break;
                }
                int textLength = int.Parse(Console.ReadLine());
                string pattern = $@"^(\d+)([A-Za-z]{{{textLength}}})([^A-Za-z]*)$";
                Regex regex = new Regex(pattern);
                var match = regex.Match(input);
               
                if (match.Success)
                {
                    var left = match.Groups[1].Value;
                    var message = match.Groups[2].Value;
                    var right = match.Groups[3].Value;

                    var indexes = string.Concat(left, right)
                        .Where(d => char.IsDigit(d))
                        .Select(d => d - '0').ToArray();
                    
                    StringBuilder sb = new StringBuilder();
                    PrintTheMessage(indexes, message, sb);
                }
                
                
            }
        }

        private static void PrintTheMessage(int[] indexes, string message,StringBuilder sb)
        {
            for (int i = 0; i < indexes.Length; i++)
            {

                if (indexes[i] > message.Length - 1)
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(message[indexes[i]]);
                }
            }
            Console.WriteLine($"{message} == {sb.ToString()}");
        }
    }
}
