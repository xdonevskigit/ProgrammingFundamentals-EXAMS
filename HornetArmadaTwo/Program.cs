using System;
using System.Collections.Generic;
using System.Linq;

namespace HornetArmadaTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var legionActivity = new Dictionary<string, int>();
            var legionSoldiers = new Dictionary<string, Dictionary<string, long>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { '=', '>', '-', ':', ' ' }
                , StringSplitOptions.RemoveEmptyEntries).ToArray();

                int activity = int.Parse(input[0]);
                string name = input[1];
                string type = input[2];
                long count = long.Parse(input[3]);

                if (!legionActivity.ContainsKey(name))
                {
                    legionActivity.Add(name, activity);
                }
                else
                {
                    if (legionActivity[name] < activity)
                    {
                        legionActivity[name] = activity;
                    }
                }
                if (!legionSoldiers.ContainsKey(name))
                {
                    legionSoldiers.Add(name, new Dictionary<string, long>());
                    legionSoldiers[name].Add(type, count);
                }
                else if (!legionSoldiers[name].ContainsKey(type))
                {
                    legionSoldiers[name].Add(type, count);
                }
                else
                {
                    legionSoldiers[name][type] += count;
                }
            }
            string[] search = Console.ReadLine().Split('\\');
            if (search.Length == 1)
            {
                string searchType = search[0];

                foreach (var item in legionActivity.OrderByDescending(s => s.Value))
                {
                    if (legionSoldiers[item.Key].ContainsKey(searchType))
                    {
                        Console.WriteLine($"{item.Value} : {item.Key}");
                    }
                }
            }
           else
           {
               int searchActivity = int.Parse(search[0]);
               string searchType = search[1];
               foreach (var soldier in legionSoldiers
                    .Where(l => l.Value.ContainsKey(searchType))
                    .OrderByDescending(s => s.Value[searchType]))
               {
                   if (legionActivity[soldier.Key] < searchActivity)
                   {
                       Console.WriteLine($"{soldier.Key} -> {soldier.Value[searchType]}");
                   }
               }
           }
        }
    }
}
