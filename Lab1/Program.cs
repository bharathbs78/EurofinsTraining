using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int product =  3 * 4 * 5;//lcm of 2,3,4,5,6
            int j = 1;
            for(int i=1;i<=4;i++)
            {
                while ((7 * j) % product != 1)
                {
                    j++;
                }
                if (i == 1 || i == 2 || i == 4 )
                {
                    Console.WriteLine(j*7);
                }
                j++;
            }
        }
    }
}
