using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class q4
    {
        public static void Main(string[] args)
        {
            double number = Convert.ToDouble(Console.ReadLine());
            double rem = number % 1.0;
            rem = Convert.ToDouble(String.Format("{0:0.00}", rem));
            int whole = (int)number;
            Console.WriteLine("Whole number" + whole);
            Console.WriteLine("Decimal part"+rem);
        }

    }
}
