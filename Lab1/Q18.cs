using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Q18
    {
        static void Main(string[] args)
        {
            string itemCode, desc;
            int qty = 0;
            double price = 0.0, granTot = 0.0;
            char modePayment = 'R', choice = 'y';

            while (choice == 'Y' || choice == 'y')
            {
                Console.WriteLine("Enter item code:");
                itemCode = Console.ReadLine();
                Console.WriteLine("Enter description:");
                desc = Console.ReadLine();
                Console.WriteLine("Enter quantity:");
                qty = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter price:");
                price = double.Parse(Console.ReadLine());

                granTot += qty * price;

                Console.WriteLine("Do you want to enter more items? (y/n)");
                choice = char.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter mode of payment (R for card and C for cash):");
            modePayment = char.Parse(Console.ReadLine());

            if (granTot > 10000)
            {
                granTot *= 0.9;
            }
            else if (granTot < 1000 && modePayment == 'R')
            {
                granTot += granTot * 0.025;
            }

            Console.WriteLine("Grand total: " + granTot);

        }
    }
}
