using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Enter two numbers in different lines");
            a=Convert.ToInt32(Console.ReadLine());
            b=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("number 1 "+a);
            Console.WriteLine("number 2 "+b);
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine("numbers after swap");
            Console.WriteLine("number 1 " + a);
            Console.WriteLine("number 2 "+b);
        }
    }
}
