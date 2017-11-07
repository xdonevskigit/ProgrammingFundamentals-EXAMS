using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace HornetAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            var bees = Console.ReadLine().Trim().Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            var hornets = Console.ReadLine().Trim().Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            var aliveBees = new List<BigInteger>();

            while (bees.Count > 0)
            { 
               BigInteger hornetsSum = hornets.Sum();
                if (hornetsSum > bees[0])
                {
                    bees.RemoveAt(0);
                }
                else if (hornetsSum == bees[0])
                {
                    hornets.RemoveAt(0);
                    bees.RemoveAt(0);
                }
                else
                {
                    BigInteger surviveBees = bees[0] - hornetsSum;
                    aliveBees.Add(surviveBees);
                    bees.RemoveAt(0);
                    if (hornets.Count != 0)
                    {
                        hornets.RemoveAt(0);   
                    }
                    
                                       
                }
            }
            Console.WriteLine(aliveBees.Count == 0 ? String.Join(" ", hornets)
                 : String.Join(" ", aliveBees));
        }
    }
}
