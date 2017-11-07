using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {           
           var demons = Console.ReadLine()
                .Split(", ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                .Select(Demon.Parse)
                .OrderBy(d => d.Name)
                .ToArray();

          foreach (var demon in demons)
          {
              Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damege:F2} damage");
          }
        }
    }
    public class Demon
    {
        public string Name { get; set; } 
        public decimal Health { get; set; }
        public decimal Damege { get; set; }

        public static Demon Parse(string demonName)
        {
            Demon demon = new Demon();
            demon.Name = demonName;
            demon.Health = CalculateHealth(demonName);
            demon.Damege = CalculateDamage(demonName);

            return demon;
        }
       private static decimal CalculateDamage(string demonName)
        {
            string damagePattern = @"[+-]?\d+(:?\.?\d+)?";
            var damageNumbers = Regex.Matches(demonName, damagePattern);
            decimal damageSum = 0;
            foreach (Match item in damageNumbers)
            {
                damageSum += decimal.Parse(item.Value);          
            }

            var modifires = demonName.Where(d => d == '*' || d == '/').ToArray();
            foreach (var modifire in modifires)
            {
                switch (modifire)
                {
                    case '*':
                        damageSum = damageSum * 2;
                        break;
                    case '/':
                        damageSum = damageSum / 2;
                        break;
                }
            }
            return damageSum;
        }       
        private static decimal CalculateHealth(string demonName)
        {
            var healthPattern = @"[^0-9+\-*\/\.]";
            var matchHealth = Regex.Matches(demonName, healthPattern)
                .Cast<Match>()
                .Select(x => char.Parse(x.Value))
                .ToArray();
            var healthList = new List<decimal>();

            foreach (var item in matchHealth)
            {
                healthList.Add(item);
            }
            var health = healthList.Sum();
            return health;
        }
    }
}
