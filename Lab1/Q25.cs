using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q25
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int k = 1;
            int sign = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($" {Math.Pow(k,2)*sign}");
                    k++;
                    sign *= -1;
                }
                Console.WriteLine();
            }
            int a = 1, b = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($" {a}");
                    a = a*b;
                    b++;
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n; i++)
            {
                for(int k1=n;k1>i;k1--)
                    Console.Write("  ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write($"* ");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n; i++)
            {
                for (int k1 = n; k1 > i; k1--)
                    Console.Write(" ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write($"* ");
                }
                Console.WriteLine();
            }
        }
    }
}
