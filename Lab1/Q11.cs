using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q11
    {
        static void Main(string[] args)
        {
            int num,tmp;
            Console.WriteLine("Enter num");
            num=int.Parse(Console.ReadLine());
            string str="";
            string[] array = {"zero","one","two","three","four","five","six","seven","eight","nine"};
            while (num != 0)
            {
                tmp = num % 10;
                num = num / 10;
                str = array[tmp]+" "+str;
            }
            Console.WriteLine(str);
        }
    }
}
