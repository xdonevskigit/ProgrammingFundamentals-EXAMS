using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            long PokePower = long.Parse(Console.ReadLine());
            long distaance = long.Parse(Console.ReadLine());
            long exFactor = long.Parse(Console.ReadLine());

            decimal halfPower = (decimal)PokePower / 2;
            long count = 0;

            while (true)
            {
                Calculate:
                PokePower = PokePower - distaance;
                count++;
                if (PokePower == halfPower)
                {
                    if (exFactor == 0)
                    {
                        goto Calculate; 
                    }
                    else
                    {
                        PokePower = PokePower / exFactor;
                        if (PokePower >= distaance)
                        {
                            goto Calculate;
                        }
                        break;
                    }                   
                }
                if (PokePower < distaance)
                {
                    break;
                }
            }
            Console.WriteLine(PokePower);
            Console.WriteLine(count);
        }
    }
}
