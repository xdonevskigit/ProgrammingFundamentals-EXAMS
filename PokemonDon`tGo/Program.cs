using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDon_tGo
{
    class Program
    {
        public static long sum = 0;
        static void Main()
        {
            List<long> area = new List<long>();
            area = Console.ReadLine().Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            while (area.Count > 0)
            {
                int arrIndex = int.Parse(Console.ReadLine());
                if (arrIndex >= 0 && arrIndex <= area.Count - 1)
                {
                    area = RemoveAndChangeTheElements(area, arrIndex);
                }
                else if (arrIndex < 0)
                {
                    area = DuplicateTheLastIndex(area);
                }
                else
                {
                    area = DuplicateTheFirstIndex(area);
                }
            }
            Console.WriteLine(sum);
        }

        public static List<long> DuplicateTheFirstIndex(List<long> area)
        {
            long element = area[area.Count - 1];
            area[area.Count - 1] = area[0];
            
            sum = sum + element;
            for (int i = 0; i < area.Count; i++)
            {
                if (area[i] <= element)
                {
                    area[i] += element;
                }
                else
                {       
                    area[i] -= element;
                }
            }

            return area;
        }

        public static List<long> DuplicateTheLastIndex(List<long> area)
        {
            long element = area[0];
            area[0] = area[area.Count - 1];
            
            sum = sum + element;
            for (int i = 0; i < area.Count; i++)
            {
                if (area[i] <= element)
                {
                    area[i] += element;
                }
                else
                {
                    area[i] -= element;
                }
            }

            return area;
        }

        public static List<long> RemoveAndChangeTheElements(List<long> area, int arrIndex)
        {
            long element = area[arrIndex];
            sum = sum + element;
            if (element == 0)
            {
                return area;
            }
            area.RemoveAt(arrIndex);

            for (int i = 0; i < area.Count; i++)
            {
                if (area[i] <= element)
                {
                    area[i] += element;
                }
                else
                {
                    area[i] -= element;
                }
            }
            return area;
        }
    }
}
