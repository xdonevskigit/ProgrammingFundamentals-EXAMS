using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HornetComm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();
            List<string> broadcast = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                
                string[] tokens = input.Split(new string[] { " <-> " }
                , StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens[0] == "Hornet is Green")
                {
                    PrintTheResult(messages, broadcast);
                    return;
                }
                if (tokens.Length != 2)
                {
                    continue;
                }
                string firstStr = tokens[0];
                string secondStr = tokens[1];

                if (firstStr.All(Char.IsDigit) && secondStr.All(Char.IsLetterOrDigit))
                {
                    char[] chArr = firstStr.Reverse().ToArray();
                    string reversedNums = new string(chArr);
                    messages.Add($"{reversedNums} -> {secondStr}");

                }
                else if (secondStr.All(Char.IsLetterOrDigit) && firstStr.All(c => !char.IsDigit(c)))
                {
                    string revCases = ReverseAllCases(secondStr);
                    broadcast.Add($"{revCases} -> {firstStr}");
                }
            }          
        }
        private static string ReverseAllCases(string secondStr)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < secondStr.Length; i++)
            {
                
                if (Char.IsUpper(secondStr[i]))
                {
                    sb.Append(Char.ToLower(secondStr[i]));
                }
                else if (Char.IsLower(secondStr[i]))
                {
                    sb.Append(Char.ToUpper(secondStr[i]));
                }
                else
                {
                    sb.Append(secondStr[i]);
                }
                                   
            }
            return sb.ToString();
        }

        private static void PrintTheResult(List<string> messages, List<string> broadcast)
        {
            Console.WriteLine("Broadcasts:");
            Console.WriteLine(broadcast.Count == 0 ? "None" : 
                String.Join(Environment.NewLine, broadcast));
            Console.WriteLine("Messages:");
            Console.WriteLine(messages.Count == 0 ? "None" :
                String.Join(Environment.NewLine, messages));
        }
    }
}
