using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q24
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int k = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($" {j+1}");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($" {i}");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($" {k++}");
                }
                Console.WriteLine();
            }
            int a = 0, b = 0, sum = 1; ;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($" {sum}");
                    a = b;
                    b = sum;
                    sum = a + b;
                }
                Console.WriteLine();
            }
        }
    }
}
