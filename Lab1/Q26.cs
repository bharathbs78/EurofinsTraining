using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q26
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            for(int i=0;i<arr.Length;i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter n");
            int n=int.Parse(Console.ReadLine());
            foreach (int i in arr)
            {
                if (n == i)
                {
                    Console.WriteLine("Found");
                    break;
                }
            }
        }
    }
}
