using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal wingFlaps = decimal.Parse(Console.ReadLine());
            decimal distFor1000FlapsInMeters = decimal.Parse(Console.ReadLine());
            decimal hornetEndurance = decimal.Parse(Console.ReadLine());

            decimal restInSec = Math.Floor(wingFlaps / hornetEndurance);
            restInSec = restInSec * 5;
            restInSec = restInSec + (wingFlaps / 100);
            decimal distance = (wingFlaps / 1000) * distFor1000FlapsInMeters;
            Console.WriteLine($"{distance:F2} m.");
            Console.WriteLine($"{restInSec} s.");
        }
    }
}
