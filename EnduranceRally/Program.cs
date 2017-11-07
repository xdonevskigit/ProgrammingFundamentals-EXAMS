using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries).ToArray();
            double[] fuelZones = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();
            int[] indexOfZones = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            foreach (var name in names)
            {               
                 double driverFuel = name[0];

                for (int i = 0; i < fuelZones.Length; i++)
                {                    
                    if (indexOfZones.Any(x => x.Equals(i)))
                    {
                        driverFuel += fuelZones[i];
                    }
                    else
                    {
                        driverFuel -= fuelZones[i];
                    }
                    if (driverFuel <= 0)
                    {
                        Console.WriteLine($"{name} - reached {i}");
                        break;
                    }
                }
                if (driverFuel > 0)
                {
                    Console.WriteLine($"{name} - fuel left {driverFuel:F2}");
                }
                
                
            }
        }
    }
}
