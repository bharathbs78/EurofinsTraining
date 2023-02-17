using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q16
    {
        static void Main(string[] args)
        {
            int bin = int.Parse(Console.ReadLine());
            int rem = 0;
            int dec = 0;
            int i = 0;
            while (bin != 0)
            {
                rem = bin % 10;
                bin = bin / 10;
                dec =dec+ (rem * Convert.ToInt32(Math.Pow(2, i)));
                i++;
            }
            Console.WriteLine(dec);
        }
    }
}
