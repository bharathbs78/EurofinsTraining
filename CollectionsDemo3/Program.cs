using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = 10;
            //int x = a;
            //object obj = x;//boxing
            //a = (int)obj;//unboxing
            List<int> ints = new List<int>();
            Console.WriteLine(ints.Capacity);
            ints.Add(1);
            ints.Add(0);
            int x = ints[1];
            Console.WriteLine(ints.Capacity);// gives memory spaces
            Console.WriteLine( ints.Count);//gives used memory spaces
        }
    }
}
