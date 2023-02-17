using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q21
    {
        static void Main(string[] args)
        {
            string str=Console.ReadLine();
            string rev = "";
            foreach(char c in str)
            {
                rev = c + rev;
            }
            Console.WriteLine(rev);
        }
    }
}
