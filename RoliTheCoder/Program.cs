using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RoliTheCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventsInfo = new Dictionary<string, Event>();
            
            while (true)
            {                
                string input = Console.ReadLine();
                if (input == "Time for Code")
                {
                    PrintTheInfo(eventsInfo);
                    break;
                }
                if (!input.Contains("#"))
                {
                    continue;
                }
                string[] inputTokens = input.Trim().Split(new char[] { ' ', '#', '@' }
                , StringSplitOptions.RemoveEmptyEntries).ToArray();
                string eventId = inputTokens[0];
                string eventName = inputTokens[1];
                string chechPattern = "^[A-Za-z-'0-9]+$";
                if (!eventsInfo.ContainsKey(eventId))
                {
                    eventsInfo.Add(eventId, new Event());
                    eventsInfo[eventId].EventName = eventName;
                    eventsInfo[eventId].Participles = new HashSet<string>();
                    foreach (var item in inputTokens.Skip(2))
                    {
                        if (Regex.Match(item, chechPattern).Success)
                        {
                            eventsInfo[eventId].Participles.Add(item);
                        }
                        
                    }
                }
                else if (eventsInfo.ContainsKey(eventId) && !eventsInfo[eventId].EventName.Contains(eventName))
                {
                    continue;
                }
                else if (eventsInfo.ContainsKey(eventId) && eventsInfo[eventId].EventName.Contains(eventName))
                {
                    foreach (var item in inputTokens.Skip(2))
                    {
                        if (Regex.Match(item, chechPattern).Success)
                        {
                            eventsInfo[eventId].Participles.Add(item);
                        }
                    }
                }
                
            }
        }
        private static void PrintTheInfo(Dictionary<string, Event> eventsInfo)
        {
            foreach (var item in eventsInfo.OrderByDescending
                (e => e.Value.Participles.Count()).ThenBy(e => e.Value.EventName))
            {
                Console.WriteLine(item.Value.EventName + " - " + item.Value.Participles.Count());
                foreach (var people in item.Value.Participles.OrderBy(x => x))
                {
                    Console.WriteLine($"@{people}");
                }
            }
        }
    }
    public class Event
    {
        public string EventName { get; set; } 
        public HashSet<string> Participles { get; set; }
    }
}
