using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q9
    {
        static void Main(string[] args)
        {
            int n,sum=0;
            int i=1;
            Console.WriteLine("Enter n");
            n=int.Parse(Console.ReadLine());
            while (n--!=0)
            {
                sum += i;
                i += 2;
            }
            Console.WriteLine(sum);
        }
    }
}
