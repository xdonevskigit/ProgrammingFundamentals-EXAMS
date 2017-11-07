using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamGols = new Dictionary<string, int>();
            var teamPoints = new Dictionary<string, int>();

            string key = Console.ReadLine();
            //    ^
            //   / \
            //  / ! \
            // /  !  \
            // ^^^^^^^
            key = Regex.Escape(key);
            while (true)
            {

                string input = Console.ReadLine();
                if (input == "final")
                {
                    PrintTheStats(teamGols, teamPoints);
                    break;
                }
                
                string pattern = $@"{key}(\w*?){key}";
                string patternTwo = "[0-9]+:[0-9]+";
                Regex regex = new Regex(pattern);
                Regex regexTwo = new Regex(patternTwo);
                var regexNames = regex.Matches(input);
                string result = regexTwo.Match(input).ToString();
                List<string> teamNames = new List<string>();
                foreach (Match names in regexNames)
                {                   
                    teamNames.Add(names.Groups[1].ToString().ToUpper());
                }
                for (int i = 0; i < teamNames.Count; i++)
                {
                     char[] arr = teamNames[i].ToCharArray();
                     Array.Reverse(arr);
                     teamNames[i] = new string(arr);
                }

                
                string[] resultArr = result.Split(':').ToArray();
                int[] points = CalculateThePoints(resultArr);
                for (int i = 0; i < teamNames.Count; i++)
                {
                    if (!teamGols.ContainsKey(teamNames[i]))
                    {
                        teamGols.Add(teamNames[i], int.Parse(resultArr[i].ToString()));
                    }
                    else
                    {
                        teamGols[teamNames[i]] += int.Parse(resultArr[i].ToString());
                    }
                    if (!teamPoints.ContainsKey(teamNames[i]))
                    {
                        teamPoints.Add(teamNames[i], points[i]);
                    }
                    else
                    {
                        teamPoints[teamNames[i]] += points[i];
                    }
                }
                
                
            }
            
        }

        private static int[] CalculateThePoints(string[] result)
        {
            int first = int.Parse(result[0].ToString());
            int second = int.Parse(result[1].ToString());
            int[] arr = new int[2];
            if (first == second)
            {
                arr[0] = 1;
                arr[1] = 1;
            }
            else if (first > second)
            {
                arr[0] = 3;
                arr[1] = 0;
            }
            else
            {
                arr[0] = 0;
                arr[1] = 3;
            }
            return arr;
        }

        private static void PrintTheStats(Dictionary<string, int> teamGols, Dictionary<string, int> teamPoints)
        {
            Console.WriteLine("League standings:");
            int count = 1;
            foreach (var item in teamPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{count}. {item.Key} {item.Value}");
                count++;
            }

            Console.WriteLine("Top 3 scored goals:");
             count = 0;
            foreach (var item in teamGols.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                if (count == 3)
                {
                    break;
                }
                Console.WriteLine($"- {item.Key} -> {item.Value}");
                count++;
            }
        }
    }
}
