using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SoftUniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;
            for (int i = 0; i < count; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string dateString = Console.ReadLine();
                long capsules = long.Parse(Console.ReadLine());
                int[] dates = dateString.Split('/').Select(int.Parse).ToArray();
                int days = DateTime.DaysInMonth(dates[2],dates[1]);

                decimal priceForMonth = days * capsules * pricePerCapsule;
                totalPrice = totalPrice + priceForMonth;
                Console.WriteLine($"The price for the coffee is: ${priceForMonth:F2}");
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");

        }
    }
}
