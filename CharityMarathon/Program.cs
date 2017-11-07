using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityMarathon
{
    class Program
    {
        static void Main(string[] args)
        {
            long marathonLengthInDays = long.Parse(Console.ReadLine());
            long numberOfRunners = long.Parse(Console.ReadLine());
            long averageNumberOfLaps = long.Parse(Console.ReadLine());
            long lengthOfTheTrack = long.Parse(Console.ReadLine());
            long capacityOfTheTrack = long.Parse(Console.ReadLine());
            decimal amountMoneyDonate = decimal.Parse(Console.ReadLine());
            if (capacityOfTheTrack * marathonLengthInDays < numberOfRunners)
            {
                numberOfRunners = capacityOfTheTrack * marathonLengthInDays;
            }
            decimal totalMeters = numberOfRunners * averageNumberOfLaps * lengthOfTheTrack;
            decimal totalKilometers = totalMeters / 1000;
            decimal totalMoneyRaised = amountMoneyDonate * totalKilometers;
            Console.WriteLine($"Money raised: {totalMoneyRaised:F2}");
        }
    }
}
