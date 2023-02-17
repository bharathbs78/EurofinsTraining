using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q22
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string rev = "";
            foreach (char c in str)
            {
                rev = c + rev;
            }
            if(rev.Equals(str))
                Console.WriteLine("true");
            else Console.WriteLine("false");
        }
    }
}
