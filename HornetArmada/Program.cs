using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var legionActivity = new Dictionary<string, long>();
            var soldiers = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(new char[] { ' ', '=', '>', '-', ':' }
                , StringSplitOptions.RemoveEmptyEntries).ToArray();

                int activity = int.Parse(tokens[0]);
                string name = tokens[1];
                string type = tokens[2];
                long count = int.Parse(tokens[3]);

                if (!legionActivity.ContainsKey(name))
                {
                    legionActivity.Add(name, activity);
                    soldiers.Add(name, new Dictionary<string, long>());
                    soldiers[name].Add(type, count);
                }
                else if (soldiers[name].ContainsKey(type))
                {
                    soldiers[name][type] += count;                   
                }
                else if (!soldiers[name].ContainsKey(type))
                {
                    soldiers[name].Add(type, count);
                    if (legionActivity.Values.Max() < activity)
                    {
                        legionActivity[name] = activity;
                    }
                }
                if (legionActivity.ContainsKey(name))
                {
                    if (legionActivity[name] < activity)
                    {
                        legionActivity[name] = activity;
                    }
                }
            }
            string autputInfo = Console.ReadLine();
            string[] tokensEnd = autputInfo.Split(new char[] { '\\' }
            , StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (tokensEnd.Length == 2)
            {
                PrintTheLegionNamesAndSoldierCounts(tokensEnd, soldiers, legionActivity);
            }
            else if (tokensEnd.Length == 1)
            {
                PrintTheLastActivityAndLegionName(tokensEnd, legionActivity , soldiers);
            }
        }

        private static void PrintTheLastActivityAndLegionName(string[] tokensEnd
            , Dictionary<string, long> legionActivity
            , Dictionary<string, Dictionary<string, long>> soldiers)
        {
            string type = tokensEnd[0];
            var legionList = new List<string>();
            foreach (var kvp in soldiers)
            {
                foreach (var item in kvp.Value)
                {
                    if (type == item.Key)
                    {
                        legionList.Add(kvp.Key);
                    }
                }
            }
            foreach (var kvp in legionActivity.OrderByDescending(s => s.Value))
            {
                if (legionList.Contains(kvp.Key))
                {
                    Console.WriteLine($"{kvp.Value} : {kvp.Key}");
                }
            }
        }

        private static void PrintTheLegionNamesAndSoldierCounts(string[] tokensEnd
            , Dictionary<string, Dictionary<string, long>> soldiers
            , Dictionary<string, long> legionActivity)
        {
            var dic = new Dictionary<string, long>();
            string type = tokensEnd[1];
            int activity = int.Parse(tokensEnd[0]);
            foreach (var act in legionActivity)
            {              
                foreach (var kvp in soldiers)
                {
                    foreach (var item in kvp.Value.OrderBy(s => s.Value))                        
                        if (type == item.Key && act.Value < activity && act.Key == kvp.Key)
                        {
                            dic.Add(kvp.Key, item.Value);
                        }

                }
            }
            foreach (var kvp in dic.OrderByDescending(s => s.Value))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
