using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q1
    {
        static void Main(string[] args)
        {
            double principle, rate, time;
            principle = double.Parse(Console.ReadLine());
            rate = double.Parse(Console.ReadLine());
            time = double.Parse(Console.ReadLine());
            Console.WriteLine(principle*rate*time/100);
        }
    }
}
