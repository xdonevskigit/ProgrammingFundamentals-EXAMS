using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDessert
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double numberOfGuests = double.Parse(Console.ReadLine());
            double bananaPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double berryPrice = double.Parse(Console.ReadLine());

            double portions = Math.Ceiling(numberOfGuests / 6);
            double allProductPrice = (portions * (bananaPrice * 2))
                + (portions * (eggsPrice * 4))
                + (portions * (berryPrice * 0.2));
            if (money >= allProductPrice )
            {
                Console.WriteLine($"Ivancho has enough money - it would cost { allProductPrice:F2}lv.");
            }
            else
            {
                double needetMoney = allProductPrice - money;
                Console.WriteLine($"Ivancho will have to withdraw money - he will need { needetMoney:F2}lv more.");
            }
        }
    }
}
