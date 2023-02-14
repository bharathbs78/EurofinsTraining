using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q10
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Enter num");
            num=int.Parse(Console.ReadLine());
            int rev=0,tmp;
            while (num != 0)
            {
                tmp = num % 10;
                num = num / 10;
                rev = rev * 10 + tmp;
            }
            Console.WriteLine(rev);
        }
    }
}
