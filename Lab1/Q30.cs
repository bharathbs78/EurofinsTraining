using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q30
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter m");
            int m = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
            if (n == m)
            {
                int notSymmetric=0;
                int i;
                for(i=0;i<n;i++)
                {
                    for(int j = 0; j < m; j++){
                        if (arr[i, j] != arr[j, i])
                        {
                            Console.WriteLine("Not symmetric");
                            notSymmetric++;
                            break;
                        }
                    }
                    if (notSymmetric != 0)
                    {
                        break;
                    }
                }
                if (i >= n)
                {
                    Console.WriteLine("Symmetric");
                }
            }
        }
    }
}
