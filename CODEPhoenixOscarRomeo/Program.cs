using System;
using System.Collections.Generic;
using System.Linq;

namespace CODEPhoenixOscarRomeo
{
    class Program
    {
        static void Main(string[] args)
        {
            var squad = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Blaze it!")
                {
                    PrintTheResult(squad);
                    return;
                }
                string[] tokens = input.Split(new char[] { ' ', '-', '>' }
                , StringSplitOptions.RemoveEmptyEntries).ToArray();
                string sqCrqator = tokens[0];
                string member = tokens[1];
                if (sqCrqator == member)
                {
                    continue;
                }
                if (!squad.ContainsKey(sqCrqator))
                {
                    squad.Add(sqCrqator, new List<string>());
                    squad[sqCrqator].Add(member);
                }
                else if (!squad[sqCrqator].Contains(member))
                {
                    squad[sqCrqator].Add(member);
                }
            }
        }

        private static void PrintTheResult(Dictionary<string, List<string>> squad)
        {
                foreach (var kvp in squad)
                {
                    foreach (var kvpTwo in squad)
                    {
                       if (squad[kvp.Key].Contains(kvpTwo.Key) 
                        && squad[kvpTwo.Key].Contains(kvp.Key))
                       {
                        squad[kvp.Key].Remove(kvpTwo.Key);
                        squad[kvpTwo.Key].Remove(kvp.Key);
                       }
                    }
                }
            foreach (var item in squad.OrderByDescending(s => s.Value.Count))
            {
                Console.WriteLine($"{item.Key} : {item.Value.Count}");
            }
        }
    }
}
