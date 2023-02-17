using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q15
    {
        static void Main(string[] args)
        {
            int num;
            int rem;
            string binary="";
            Console.WriteLine("Enter num");
            num=int.Parse(Console.ReadLine());
            while(num!=0)
            {
                rem = num % 2;
                num = num / 2;
                binary = rem + binary;
            }
            Console.WriteLine(binary);
        }
    }
}
