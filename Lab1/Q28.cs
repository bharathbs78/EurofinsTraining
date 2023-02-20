using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q28
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter m");
            int m=int.Parse(Console.ReadLine());
            int[,] arr = new int[n,m];
            for (int i=0;i<n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    arr[i,j]=int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i,j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[j, i]);
                }
                Console.WriteLine();
            }

        }
    }
}
