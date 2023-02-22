using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(){ 1,2,3,4,5,6,7,8,9 };
           // Func<int, bool> filter = new Func<int, bool>(isEven);
            int evenSum = list.Where(num=>num%2==0).Sum();
            Console.WriteLine(evenSum);
        }
        //static bool isEven(int num)
        //{
        //    return (num%2==0);
        //}
    }
}
