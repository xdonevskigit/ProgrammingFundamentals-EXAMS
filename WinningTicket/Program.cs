using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split(new char[] {' ', ',' }
            , StringSplitOptions.RemoveEmptyEntries).ToArray();
            var dic = new Dictionary<int, string>();
            int count = 0;
            if (!input.Any())
            {
                Console.WriteLine("invalid ticket");
                return;
            }
            foreach (var item in input[count])
            {
                if (count == input.Length)
                {
                    break;
                }
                dic.Add(count, input[count]);
                count++;
            }

            foreach (var item in dic)
            {

                if (item.Value.Count() == 20)
                {
                    string left = dic[item.Key].Substring(0, 10);

                    string right = dic[item.Key].Substring(10, 10);

                    int longestLeftGroup = LongestSequenceOfRepeatElements(left)[0];
                    char leftSymbol = left[LongestSequenceOfRepeatElements(left)[1]];
                    int longestRightGroup = LongestSequenceOfRepeatElements(right)[0];
                    char rightSymbol = right[LongestSequenceOfRepeatElements(right)[1]];

                    int min = Math.Min(longestLeftGroup, longestRightGroup);

                    if (left == right && min == 10)
                    {
                        if (leftSymbol == '$' || leftSymbol == '@'
                           || leftSymbol == '#' || leftSymbol == '^')
                        {
                        Console.WriteLine($"ticket \"{item.Value}\" - 10{leftSymbol} Jackpot!");

                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{item.Value}\" - no match");
                        }

                    }

                    else if (leftSymbol == rightSymbol
                                 && min > 5
                                 && min < 10)
                    {
                        if (leftSymbol == '$' || leftSymbol == '@'
                           || leftSymbol == '#' || leftSymbol == '^')
                        {
                            Console.WriteLine($"ticket \"{item.Value}\" - {min}{leftSymbol}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{item.Value}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
        public static int[] LongestSequenceOfRepeatElements(string a)
        {
            int[] result = new int[2];
            int bestStart = 0;
            int bestCount = 0;
            int count = 1;
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] == a[i + 1])
                {
                    count++;
                    if (count > bestCount)
                    {
                        bestStart = i;
                        bestCount = count;
                    }
                    
                }
                else
                {
                   count = 1;
                }
            }
            result[0] = bestCount;
            result[1] = bestStart;
            return result;
        }
    }
}
