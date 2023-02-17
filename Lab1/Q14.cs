using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q14
    {
        static void Main(string[] args)
        {
            int n;
            n=int.Parse(Console.ReadLine());
            if(n==0)
                Console.WriteLine("1");
            else if(n<0)
                Console.WriteLine("Invalid");
            else
            {
                int product = 1;
                while (n != 0)
                {
                    product *= n;
                    n--;
                }
                Console.WriteLine(product);
            }
        }
    }
}
