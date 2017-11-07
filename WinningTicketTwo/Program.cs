using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinningTicketTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ' ', ',' }
            , StringSplitOptions.RemoveEmptyEntries)
            .Select(t => t.Trim())
            .ToArray();
            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                string left = new String(ticket.Take(10).ToArray());
                string right = new String(ticket.Skip(10).ToArray());
                bool winningTicket = false;
                int minFoundSymbols = 0;

                string[] winningSymbols = { "\\^", "\\$", "#", "@" };
                foreach (var symbol in winningSymbols)
                {
                    var regex = new Regex($"{symbol}{{6,}}");
                    var leftMatch = regex.Match(left);
                    if (leftMatch.Success)
                    {
                        var rightMatch = regex.Match(right);
                        if (rightMatch.Success)
                        {
                            minFoundSymbols = Math.Min(leftMatch.Length, rightMatch.Length);
                            winningTicket = true;
                            var jackpot = leftMatch.Length == 10 && rightMatch.Length == 10
                                ? " Jackpot!"
                                : string.Empty;
                            Console.WriteLine($"ticket \"{ticket}\" - {minFoundSymbols}{symbol.Trim('\\')}{jackpot}");
                            break;
                        }
                    }
                }
                if (!winningTicket)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
            
        }
    }
}
