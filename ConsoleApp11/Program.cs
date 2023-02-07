using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int principle, rate, time;
            int SI;
            Console.WriteLine("Enter principle, rate, time one in different lines");
            principle=Convert.ToInt32(Console.ReadLine());
            rate=Convert.ToInt32(Console.ReadLine());
            time=Convert.ToInt32(Console.ReadLine());
            SI = principle * time * rate / 100;
            Console.WriteLine("The simple interest is "+SI);
        }
    }
}
